using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GiftShop.Models;
using BLL;
using PresentationLayer.Services;
using PresentationLayer.Models;

namespace GiftShop.Controllers
{
    public class HomeController : Controller
    {
        IService<GroupDTO> groupService;
        public HomeController(IService<GroupDTO> groupService)
        {
            this.groupService = groupService;
        }

        public IActionResult Index()
        {
            return View(groupService.GetAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
