using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Services;
using BLL.Filters;
using GiftShop.Areas.ProductList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace GiftShop.Areas.ProductList.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IMapper _mapper;
        private IService<GoodsDTO> goodsService;
        private IService<PropertyDTO> propService;
        public GoodsController(IService<GoodsDTO> goodsService,
                               IService<PropertyDTO> propService,
                               IMapper mapper)
        {
            this.goodsService = goodsService;
            this.propService = propService;
            this._mapper = mapper;
        }

        [Area("ProductList")]
        //public IActionResult Index(int? groupId)
        public IActionResult Index(ProductListViewModel productVM)
        {
            ProductListViewModel model = new ProductListViewModel();
            if (productVM.GroupId.HasValue)
            {
                List<GoodsDTO> filteredGoods = goodsService.GetAll().GetGoodsByGroup(productVM.GroupId.Value).ToList();

                // Упорядочение фильтра
                IEnumerable<PropertyDTO> prop = propService.GetAll()
                    .Where(x => x.GroupId == productVM.GroupId && x.IsFilter == true)
                    .ToList();

                foreach (PropertyDTO property in prop)
                {
                    property.Charact = property.Charact.Distinct().ToList();
                }

                FilterViewModel groupedProp = _mapper.Map<FilterViewModel>(prop);

                model.Filter = groupedProp;


                List<GoodsDTO> tmpFilteredGoods = new List<GoodsDTO>();
                //Filtering goods
                if (productVM?.Filter?.GroupedProperties != null)
                {
                    foreach (GroupedProperties property in productVM.Filter.GroupedProperties)
                    {
                        List<CharactItem> checkedCharacts = property.Charact.Where(x => x.AreChecked == true).ToList();
                        if (checkedCharacts != null && checkedCharacts.Count != 0)
                        {
                            foreach (CharactItem charact in checkedCharacts)
                            {
                                tmpFilteredGoods.AddRange(filteredGoods
                                    .Where(x => x.PropCharact?.FirstOrDefault(y => y.PropId == property.PropId)?.Value == charact?.Value).ToList());
                            }
                            filteredGoods = tmpFilteredGoods;
                        }
                    }
                }
                model.Goods = filteredGoods;
            }
            else
                model.Goods = goodsService.GetAll().ToList();




            return View(model);
        }

        [HttpGet]
        [Area("ProductList")]
        public IActionResult Details(int goodsId)
        {
            GoodsDTO model = goodsService.GetById(goodsId);
            return View(model);
        }

    }
}