using AutoMapper;
using BLL.Models;
using BLL.Services;
using GiftShop.Areas.StoreManage.Models;
using GiftShop.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Controllers
{
    [Area("StoreManage")]
    public class GroupController : Controller
    {
        private const string GroupImageFolderName = @"group_image";
        private const string GroupIconFolderName = @"group_icon";

        private readonly IMapper _mapper;
        private readonly IService<GroupDTO> groupService;
        private readonly IService<PropertyDTO> propService;
        IHostingEnvironment _appEnvironment;

        public GroupController(IService<GroupDTO> groupService,
                               IService<PropertyDTO> propService,
                               IMapper mapper,
                               IHostingEnvironment appEnvironment)
        {
            this.groupService = groupService;
            this.propService = propService;
            this._mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        // GET: GroupController
        public ActionResult Index()
        {
            GroupViewModel createModel = new GroupViewModel();

            createModel.Groups = groupService.GetAll().ToList();


            return View(createModel);
        }

        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            CreateGroupViewModel createModel = new CreateGroupViewModel();
            createModel.Group = new GroupDTO();
            return View(createModel);
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGroupViewModel createModel)
        {
            try
            {
                groupService.Add(createModel.Group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            GroupDTO group = groupService.GetById(id);
            CreateGroupViewModel createModel = new CreateGroupViewModel();
            createModel.Group = group;
            return View(createModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateGroupViewModel createModel)
        {
            try
            {
                if (createModel.GroupImage != null)
                {
                    if (!ImageFileManage.EqualsImage(createModel.GroupImage, _appEnvironment.WebRootPath, GroupImageFolderName, createModel.Group.Image))
                    {
                        List<IFormFile> img = new List<IFormFile>();
                        img.Add(createModel.GroupImage);

                        ImageFileManage.DeletePicture(createModel.Group.Image, _appEnvironment.WebRootPath, GroupImageFolderName);
                        ImageFileManage.AddPicture(img,
                                                   _appEnvironment.WebRootPath,
                                                   GroupImageFolderName);
                    }

                    createModel.Group.Image = createModel.GroupImage.FileName;
                }

                if (createModel.GroupIcon != null)
                {
                    if (!ImageFileManage.EqualsImage(createModel.GroupIcon, _appEnvironment.WebRootPath, GroupIconFolderName, createModel.Group.Icon))
                    {
                        List<IFormFile> img = new List<IFormFile>();
                        img.Add(createModel.GroupIcon);

                        ImageFileManage.DeletePicture(createModel.Group.Icon, _appEnvironment.WebRootPath, GroupIconFolderName);
                        ImageFileManage.AddPicture(img,
                                                   _appEnvironment.WebRootPath,
                                                   GroupIconFolderName);
                    }

                    createModel.Group.Icon = createModel.GroupIcon.FileName;
                }




                groupService.Edit(createModel.Group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(id);
            }
        }


        // POST: GroupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                groupService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult AddPropertyToGroup(int groupId, string propName)
        {
            PropertyDTO prop = new PropertyDTO()
            {
                GroupId = groupId,
                Name = propName
            };

            propService.Add(prop);


            List<PropertyDTO> properties = propService.GetAll().Where(x => x.GroupId == groupId).ToList();

            return PartialView("_PropertiesListPartial", properties);

        }


        [HttpPost]
        public ActionResult DeletePropertyGroup(int propId, int groupId)
        {
            propService.Delete(propId);


            List<PropertyDTO> properties = propService.GetAll().Where(x => x.GroupId == groupId).ToList();

            return PartialView("_PropertiesListPartial", properties);

        }


        [HttpPost]
        public void CheckPropertyIsFilter(int propId, bool isCheck)
        {
            PropertyDTO prop = propService.GetById(propId);
            prop.Charact = null;
            prop.IsFilter = isCheck;
            propService.Edit(prop);
        }
    }
}
