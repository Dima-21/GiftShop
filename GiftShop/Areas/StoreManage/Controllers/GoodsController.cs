using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Filters;
using BLL.Models;
using BLL.Services;
using GiftShop.Areas.StoreManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace GiftShop.Areas.StoreManage.Controllers
{
    [Area("StoreManage")]
    public class GoodsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<GoodsDTO> goodsService;
        private readonly IService<GroupDTO> groupService;
        private readonly IService<PropertyDTO> propService;
        IHostingEnvironment _appEnvironment;

        public GoodsController(IService<GoodsDTO> goodsService,
                               IService<GroupDTO> groupService,
                               IService<PropertyDTO> propService,
                               IMapper mapper,
                               IHostingEnvironment appEnvironment)
        {
            this._mapper = mapper;
            this.goodsService = goodsService;
            this.groupService = groupService;
            this.propService = propService;
            _appEnvironment = appEnvironment;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            GoodsListViewModel goodsVM = new GoodsListViewModel();


            // Подсчёт пагинации

            var pageSize = 10; // количество элементов на странице
            var count = goodsService.GetAll().Count(); // количество элементов на странице

            //var count = goodsService.GetAll().Count


            var items = goodsService.GetAll();

            // Test data
            // *********
            //for (int i = 0; i < 50; i++)
            //{
            //    //var newGood = new GoodsDTO() { Name = $"TEST {i}"};
            //    items = items.Append(items.FirstOrDefault());
            //}

            count = items.Count();
            items = items.Skip((page - 1) * pageSize)
                 .Take(pageSize);

            //var items = goodsService.GetAll()
            //                        .Skip((page - 1) * pageSize)
            //                        .Take(pageSize);

            goodsVM.PageViewModel = new PageViewModel(count, page, pageSize);
            goodsVM.Goods = _mapper.Map<List<GoodsViewModel>>(items);

            //new code

            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_ProductsTable", goodsVM);
            }
            return View(goodsVM);

            //return View(goodsVM);
        }
        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            CreateGoodsViewModel vm = new CreateGoodsViewModel();
            vm.Groups = groupService.GetAll();
            vm.Groups = vm.Groups.Prepend(new GroupDTO()
            {
                Id = int.MinValue,
                Name = "Выберите категорию"
            });

            return View(vm);
        }

        // POST: Goods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGoodsViewModel createModel)
        {
            if (createModel.Goods.Group.Id < 0)
                return View(createModel);
            //goodsService.Add(createModel.Goods);
            try
            {
                // TODO: Add insert logic here
                if (createModel?.Images?.FirstOrDefault() != null)
                {
                    // путь к папке Files
                    string path = "\\goods_image\\" + createModel.Images.First().FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        //await createModel.Images.First().CopyToAsync(fileStream);
                        createModel.Images.First().CopyTo(fileStream);
                    }

                    // Add pictures to DTO Pictures
                    if (createModel.Images.Count() != 0 && createModel.Goods.GoodsImage is null)
                        createModel.Goods.GoodsImage = new List<ImageDTO>();

                    foreach (var img in createModel.Images)
                    {
                        createModel.Goods.GoodsImage.Add(new ImageDTO()
                        {
                            Name = img.FileName
                        });
                    }

                    //FileModel file = new FileModel { Name = createModel.Images.First().FileName, Path = path };
                    //_context.Files.Add(file);
                    //_context.SaveChanges();
                }
                else
                {
                    createModel.Goods.GoodsImage = new List<ImageDTO>();
                }
                //createModel.Goods.PropCharact = createModel.Properties;
                //_mapper.Map<PropertyDTO>()
                //foreach (var prop in createModel.Properties)
                //{
                //    createModel.Goods.PropCharact.Add(new PropertyDTO()
                //    {
                //        N
                //    });
                //}

                goodsService.Add(createModel.Goods);

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
            GoodsDTO goods = goodsService.GetById(id);
            CreateGoodsViewModel vm = new CreateGoodsViewModel();
            vm.Goods = goods;
            // TODO: Do download images
            //vm.Images = goods.GoodsImage;

            vm.Groups = groupService.GetAll();
            vm.Groups = vm.Groups.Prepend(vm.Groups.First(x => x.Id == goods.Group.Id));
            var groups = vm.Groups.ToList();
            groups.Remove(vm.Groups.Last(x => x.Id == goods.Group.Id));
            vm.Groups = groups;

            vm.Properties = goods.PropCharact;
            return View(vm);
        }
            // POST: Goods/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateGoodsViewModel createModel)
        {
            try
            {
                // TODO: Add update logic here
                createModel.Goods.Id = id;
                goodsService.Edit(createModel.Goods);
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
            goodsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        //public List<PropertyDTO> LoadCharacteristic(int GroupId)
        public ActionResult LoadCharacteristic(int groupId)
        {
            IEnumerable<PropertyDTO> Properties = propService.GetAll().GetPropertiesByGroup(groupId).ToList();

            return PartialView("_PropertiesPartial", Properties);
        }

        [HttpPost]
        public void CheckIsHidden(int goodsId, bool isChecked)
        {
            GoodsDTO goods = goodsService.GetById(goodsId);
            goods.IsHidden = isChecked;
            goodsService.Edit(goods);
        }

        //// POST: Goods/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}