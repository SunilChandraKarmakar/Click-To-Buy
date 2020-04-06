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

        private ICollection<Brand> BrandList()
        {
            ICollection<Brand> brandList = _iBrandManager.GetAll();
            return brandList;
        }

        private ICollection<Category> CategoryList()
        {
            ICollection<Category> categoryList = _iCategoryManager.GetAll().Where(c => c.Categoryy == null).ToList();
            return categoryList;
        }

        private ICollection<Product> ProductList()
        {
            ICollection<Product> productList = _iProductManager.GetAll();
            return productList;
        }

        public IActionResult Index()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.ProductList = ProductList();
            return View();
        }

        public IActionResult GetProductByBrand(int id)
        {                
            ICollection<Product> getProductsByBrand = ProductList().Where(p => p.BrandId == id).ToList();
            ViewBag.BrandInfo = _iBrandManager.GetById(id); ;
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View(getProductsByBrand);
        }

        public IActionResult GetProductByCategory(int id)
        {
            ICollection<Product> getProductByCategory = ProductList().Where(p => p.CategoryId == id).ToList();
            ViewBag.CategoryInfo = _iCategoryManager.GetById(id);
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View(getProductByCategory);
        }

        public IActionResult GetProductInfoByProductId(int id)
        {
            ViewBag.ProductInfo = _iProductManager.GetById(id);
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View();
        }

        public IActionResult GetAllProduct()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View(ProductList());
        }

        public IActionResult ContactUs()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
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
