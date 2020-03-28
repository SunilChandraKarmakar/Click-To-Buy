using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClickToBuy.Models;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;

namespace ClickToBuy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandManager _iBrandManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductManager _iProductManager;

        public HomeController(ILogger<HomeController> logger, IBrandManager iBrandManager, 
                             ICategoryManager iCategoryManager, IProductManager iProductManager)
        {
            _logger = logger;
            _iBrandManager = iBrandManager;
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
        }

        public IActionResult Index()
        {
            ViewBag.BrandList = _iBrandManager.GetAll();
            ViewBag.CategoryList = _iCategoryManager.GetAll().Where(c => c.Categoryy == null).ToList();
            ViewBag.ProductList = _iProductManager.GetAll();
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
