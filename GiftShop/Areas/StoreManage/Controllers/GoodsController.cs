using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Services;
using GiftShop.Areas.StoreManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Areas.StoreManage.Controllers
{
    [Area("StoreManage")]
    public class GoodsController : Controller
    {
        IService<GoodsDTO> goodsService;

        public GoodsController(IService<GoodsDTO> goodsService)
        {
            this.goodsService = goodsService;
        }

        
        public ActionResult Index()
        {
            GoodsViewModel goodsVM = new GoodsViewModel();

            goodsVM.Goods = goodsService.GetAll().ToList();

            return View(goodsVM);
        }
        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goods/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}