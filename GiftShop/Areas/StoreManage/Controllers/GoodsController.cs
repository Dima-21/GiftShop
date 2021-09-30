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
using Microsoft.AspNetCore.Authorization;
using GiftShop.Infrastructure;

namespace GiftShop.Areas.StoreManage.Controllers
{
    [Area("StoreManage")]
    [Authorize(Roles = "Админ, Модератор")]
    public class GoodsController : Controller
    {
        private const string GoodsImageFolderName = @"goods_image";
        private readonly IMapper _mapper;
        private readonly IService<GoodsDTO> goodsService;
        private readonly IService<GroupDTO> groupService;
        private readonly IService<PropertyDTO> propService;
        private readonly IService<ImageDTO> imageService;
        IHostingEnvironment _appEnvironment;

        public GoodsController(IService<GoodsDTO> goodsService,
                               IService<GroupDTO> groupService,
                               IService<PropertyDTO> propService,
                               IService<ImageDTO> imageService,
                               IMapper mapper,
                               IHostingEnvironment appEnvironment)
        {
            this._mapper = mapper;
            this.goodsService = goodsService;
            this.groupService = groupService;
            this.propService = propService;
            this.imageService = imageService;
            _appEnvironment = appEnvironment;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            GoodsListViewModel goodsVM = new GoodsListViewModel();


            // Подсчёт пагинации

            var pageSize = 10; // количество элементов на странице
            var count = goodsService.GetAll().Count(); // количество элементов на странице

            //var count = goodsService.GetAll().Count


            IEnumerable<GoodsDTO> items = goodsService.GetAll();


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
            GoodsDTO goods = goodsService.GetById(id);
            return View(goods);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            CreateGoodsViewModel vm = new CreateGoodsViewModel();
            vm.Goods = new GoodsDTO();
            vm.Goods.Group = new GroupDTO();
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
            {
                createModel.Groups = groupService.GetAll();
                createModel.Groups = createModel.Groups.Prepend(new GroupDTO()
                {
                    Id = int.MinValue,
                    Name = "Выберите категорию"
                });
                return View(createModel);
            }
            //goodsService.Add(createModel.Goods);
            try
            {
                // TODO: Add insert logic here
                if (createModel?.Images != null)
                {
                    // путь к папке Files
                    //string path = "\\goods_image\\" + createModel.Images.First().FileName;
                    //// сохраняем файл в папку Files в каталоге wwwroot
                    //using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    //{
                    //    //await createModel.Images.First().CopyToAsync(fileStream);
                    //    createModel.Images.First().CopyTo(fileStream);
                    //}

                    ImageFileManage.AddPicture(createModel.Images, _appEnvironment.WebRootPath, GoodsImageFolderName);

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

                createModel.Goods.PropCharact = createModel.Properties;
                //foreach (var prop in createModel.Properties)
                //{

                //}

                goodsService.Add(createModel.Goods);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(createModel);
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


           // Загрузка характеристик
            vm.Properties = new List<PropertyValueDTO>();
            IEnumerable<PropertyDTO> properties = propService.GetAll().GetPropertiesByGroup(groups.FirstOrDefault().Id).ToList();

            foreach (PropertyDTO property in properties)
            {
                string charactValue = goods.PropCharact.FirstOrDefault(x=>x.PropId==property.PropId)?.Value;
                vm.Properties.Add(new PropertyValueDTO()
                {
                    PropId = property.PropId,
                    Name = property.Name,
                    Charact = property.Charact.Distinct().ToList(),
                    Value = charactValue
                });
            }

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
                createModel.Goods.PropCharact = createModel.Properties;

                // Add images
                if (createModel?.Images != null)
                {
                    ImageFileManage.AddPicture(createModel.Images, _appEnvironment.WebRootPath, GoodsImageFolderName);

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
                }


                    goodsService.Edit(createModel.Goods);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(createModel);
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
            List<PropertyDTO> properties = propService.GetAll().GetPropertiesByGroup(groupId).ToList();
            List<PropertyValueDTO> propertyValue = _mapper.Map<List<PropertyValueDTO>>(properties);


            foreach (PropertyValueDTO property in propertyValue)
            {
                //model = property.Charact.Distinct().ToList();
                property.Charact = property.Charact.Distinct().ToList();
            }


            //CreateGoodsViewModel model = new CreateGoodsViewModel();
            //model.Properties = new List<PropertyValueDTO>();

            //IEnumerable<PropertyDTO> properties = propService.GetAll().GetPropertiesByGroup(groupId).ToList();

            ////List<PropertiesViewModel> propVM = new List<PropertiesViewModel>();

            //foreach (PropertyDTO property in properties)
            //{
            //    model.Properties.Add(new PropertyValueDTO()
            //    {
            //        PropId = property.PropId,
            //        Name = property.Name,
            //        Charact = property.Charact.Distinct().ToList()
            //    });
            //    //property.Charact = property.Charact.Distinct().ToList();
            //}

            //List<PropertyValueDTO> model = new List<PropertyValueDTO>();
            //IEnumerable<PropertyDTO> properties = propService.GetAll().GetPropertiesByGroup(groupId).ToList();

            ////List<PropertiesViewModel> propVM = new List<PropertiesViewModel>();

            //foreach (PropertyDTO property in properties)
            //{
            //    model.Add(new PropertyValueDTO()
            //    {
            //        PropId = property.PropId,
            //        Name = property.Name,
            //        Charact = property.Charact.Distinct().ToList()
            //    });
            //    //property.Charact = property.Charact.Distinct().ToList();
            //}
            return PartialView("_GoodsPropertyPartial", propertyValue);
        }

        [HttpPost]
        public void CheckIsHidden(int goodsId, bool isChecked)
        {
            GoodsDTO goods = goodsService.GetById(goodsId);
            goods.GoodsImage = null;
            goods.PropCharact = null;
            goods.IsHidden = isChecked;
            goodsService.Edit(goods);
        }


        [HttpPost]
        public void DeleteImage(int imageId)
        {
            ImageDTO image = imageService.GetById(imageId);
            ImageFileManage.DeletePicture(image.Name, _appEnvironment.WebRootPath, GoodsImageFolderName);

            imageService.Delete(imageId);
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