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
    [Area("ProductList")]
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

        //public IActionResult Index(int? groupId)
        public IActionResult Index(ProductListViewModel productVM, string searchString)
        {
            ProductListViewModel model = new ProductListViewModel();


            List<GoodsDTO> filteredGoods = new List<GoodsDTO>();

            // Creating a property list
            if (productVM.GroupId.HasValue)
            {
                filteredGoods = goodsService.GetAll()
                   .GetIsEnabled()
                   .GetGoodsByGroup(productVM.GroupId.Value).ToList();
                
                // Упорядочение фильтра
                IEnumerable<PropertyDTO> prop = propService.GetAll().GetListPropertyForFilterGoods(productVM.GroupId).ToList();

                foreach (PropertyDTO property in prop)
                {
                    property.Charact = property.Charact.Distinct().ToList();
                }

                FilterViewModel groupedProp = _mapper.Map<FilterViewModel>(prop);

                model.Filter = groupedProp;
            }

            // Filtering by name product
            // If you have a searchString, search by name
            if (!string.IsNullOrEmpty(searchString))
            {
                filteredGoods = goodsService.GetAll().GetIsEnabled().ToList();
                filteredGoods = filteredGoods.Where(x => x.Name.ToLower().Contains(searchString.ToLower()) == true).ToList();
            }
            else if (productVM.GroupId.HasValue)
            {
                // Filtering goods by price
                List<GoodsDTO> tmpFilteredGoods = new List<GoodsDTO>();
                if (productVM?.Filter != null)
                {
                    if (productVM.Filter.MinPrice <= 0)
                        productVM.Filter.MinPrice = decimal.ToInt32(filteredGoods.Min(x => x.Price));
                    if (productVM.Filter.MaxPrice <= 0)
                        productVM.Filter.MaxPrice = decimal.ToInt32(filteredGoods.Max(x => x.Price));

                    filteredGoods = filteredGoods.Where(x => x.Price >= productVM.Filter.MinPrice && x.Price <= productVM.Filter.MaxPrice).ToList();

                    // Filtering goods by properties
                    if (productVM?.Filter?.GroupedProperties != null)
                    {
                        foreach (GroupedProperties property in productVM.Filter.GroupedProperties)
                        {
                            // Select checked properties
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

                }
                else
                {
                    if (filteredGoods != null && filteredGoods.Count != 0)
                    {
                        if (productVM?.Filter == null || productVM.Filter.MinPrice <= 0)
                            model.Filter.MinPrice = decimal.ToInt32(filteredGoods.Min(x => x.Price));
                        if (productVM?.Filter == null || productVM.Filter.MaxPrice <= 0)
                            model.Filter.MaxPrice = decimal.ToInt32(filteredGoods.Max(x => x.Price));
                    }

                }
            }

            model.Goods = filteredGoods.OrderByDescending(x => x.Amount).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int goodsId)
        {
            GoodsDTO model = goodsService.GetById(goodsId);
            return View(model);
        }

    }
}