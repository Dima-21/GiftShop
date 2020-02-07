using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Services;
using GiftShop.Areas.ProductList.Models;
using GiftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Areas.Goods.Controllers
{
    public class GoodsController : Controller
    {
        private IService<GoodsDTO> goodsService;
        public GoodsController(IService<GoodsDTO> goodsService)
        {
            this.goodsService = goodsService;
        }
        [Area("ProductList")]
        public IActionResult Index(int? groupId)
        {
            ProductListViewModel model = new ProductListViewModel();

            model.ProductList = (goodsService as GoodsService).GetAllFiltered(null).ToList();

            return View(model);
        }
    }
}