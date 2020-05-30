﻿using System;
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
        private readonly ISliderManager _iSliderManager;
        private readonly IConditionManager _iConditionManager;
        private readonly IProductPhotoManager _iProductPhotoManager;

        public HomeController(ILogger<HomeController> logger, IBrandManager iBrandManager, 
                             ICategoryManager iCategoryManager, IProductManager iProductManager,
                             ISliderManager iSliderManager, IConditionManager iConditionManager,
                             IProductPhotoManager iProductPhotoManager)
        {
            _logger = logger;
            _iBrandManager = iBrandManager;
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
            _iSliderManager = iSliderManager;
            _iConditionManager = iConditionManager;
            _iProductPhotoManager = iProductPhotoManager;
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

        private ICollection<Condition> ConditionList()
        {
            ICollection<Condition> conditions = _iConditionManager.GetAll();
            return conditions;
        }

        private ICollection<ProductPhoto> ProductPhotos()
        {
            ICollection<ProductPhoto> productPhotos = _iProductPhotoManager.GetAll();
            return productPhotos;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.ProductList = ProductList();
            ViewBag.Sliders = _iSliderManager.GetAll().Where(s => s.Status == true).ToList();
            ViewBag.Condition = ConditionList();
            ViewBag.ProductPhotos = ProductPhotos();
            return View();
        }

        [HttpGet]
        public IActionResult GetProductByBrand(int id)
        {                
            ICollection<Product> getProductsByBrand = ProductList().Where(p => p.BrandId == id).ToList();
            ViewBag.BrandInfo = _iBrandManager.GetById(id); ;
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.Condition = ConditionList();
            return View(getProductsByBrand);
        }

        [HttpGet]
        public IActionResult GetProductByCategory(int id)
        {
            ICollection<Product> getProductByCategory = ProductList().Where(p => p.CategoryId == id).ToList();
            ViewBag.CategoryInfo = _iCategoryManager.GetById(id);
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.Condition = ConditionList();
            return View(getProductByCategory);
        }

        [HttpGet]
        public IActionResult GetProductInfoByProductId(int id)
        {
            ViewBag.ProductInfo = _iProductManager.GetById(id);
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View(ProductList());
        }

        [HttpGet]
        public IActionResult GetProductByCondition(int? id)
        {
            if (id == null)
                return NotFound();

            ICollection<Product> getProductByCondition = _iProductManager.GetAll()
                .Where(p => p.ConditionId == id).ToList();

            ViewBag.GetCondition = _iConditionManager.GetById(id);
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.Condition = ConditionList();
            return View(getProductByCondition);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            return View();
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            ViewBag.BrandList = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.ProductList = ProductList();
            return View();
        }

        public string AddToCardProductList(int id)
        {
            
            return "";
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
