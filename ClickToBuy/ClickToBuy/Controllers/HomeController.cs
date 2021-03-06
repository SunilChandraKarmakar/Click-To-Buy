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
using System.Security;

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
        private readonly IPurchaseItemManager _iPurchaseItemManager;

        public HomeController(ILogger<HomeController> logger, IBrandManager iBrandManager, 
                             ICategoryManager iCategoryManager, IProductManager iProductManager,
                             ISliderManager iSliderManager, IConditionManager iConditionManager,
                             IProductPhotoManager iProductPhotoManager, IPurchaseItemManager iPurchaseItemManager)
        {
            _logger = logger;
            _iBrandManager = iBrandManager;
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
            _iSliderManager = iSliderManager;
            _iConditionManager = iConditionManager;
            _iProductPhotoManager = iProductPhotoManager;
            _iPurchaseItemManager = iPurchaseItemManager;
        }         

        private ICollection<Product> ShowClinteSiteProduct()
        {
            ICollection<PurchaseItem> getAllPurchaseItem = _iPurchaseItemManager.GetAll();
            List<Product> storePurchaseProduct = new List<Product>();

            foreach (PurchaseItem item in getAllPurchaseItem)
            {
                Product purchaseProductDetails = _iProductManager.GetById(item.ProductId);
                storePurchaseProduct.Add(purchaseProductDetails);
            }

            List<Product> removeDuplicateProductForPurchaseProduct = storePurchaseProduct.Distinct().ToList();
            return removeDuplicateProductForPurchaseProduct;
        }

        private List<Product> HotOfferProduct()
        {
            ICollection<Product> getClinteSiteProduct = ShowClinteSiteProduct();
            List<Product> hotOfferProducts = getClinteSiteProduct.Where(p => p.OfferPrice > 0).ToList();
            return hotOfferProducts;
        }

        private void CommonComponent()
        {
            ViewBag.ClinteProductList = ShowClinteSiteProduct();
            List<Brand> getBrandForShowClinteSiteProduct = new List<Brand>();
            List<Condition> getConditionForShowClinteSiteProduct = new List<Condition>();

            foreach (Product product in ViewBag.ClinteProductList)
            {
                getBrandForShowClinteSiteProduct.Add(product.Brand);
                getConditionForShowClinteSiteProduct.Add(product.Condition);
            }

            ViewBag.BrandList = getBrandForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.CategoryList = _iCategoryManager.GetCategoryForPurchaseProduct();
            ViewBag.Condition = getConditionForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();                     
        }        

        [HttpGet]
        public IActionResult Index()
        {
            CommonComponent();
            ViewBag.Sliders = _iSliderManager.GetAll().Where(s => s.Status == true).ToList();
            ViewBag.HotOfferProduct = HotOfferProduct();                
            return View();
        }

        [HttpGet]
        public IActionResult GetProductByBrand(int id)
        {
            ICollection<Product> getProductsByBrand = ShowClinteSiteProduct()
                                .Where(s => s.BrandId == id).ToList();
            ViewBag.BrandInfo = _iBrandManager.GetById(id); ;
            CommonComponent();
            return View(getProductsByBrand);
        }

        [HttpGet]
        public IActionResult GetProductByCategory(int id)
        {
            ICollection<Product> getProductByCategory = ShowClinteSiteProduct()
                                .Where(s => s.CategoryId == id).ToList();
            ViewBag.CategoryInfo = _iCategoryManager.GetById(id);
            CommonComponent();
            return View(getProductByCategory);
        }

        [HttpGet]
        public IActionResult GetProductInfoByProductId(int id)
        {
            Product selectedProductInfo = _iProductManager.GetById(id);
            List<Product> relatedProductList = ShowClinteSiteProduct()
                .Where(scp => scp.BrandId == selectedProductInfo.BrandId).ToList();
            relatedProductList.Remove(selectedProductInfo);
            CommonComponent();
            ViewBag.ProductInfo = selectedProductInfo;
            return View(relatedProductList);
        }

        [HttpGet]
        public IActionResult GetProductByCondition(int? id)
        {
            if (id == null)
                return NotFound();

            ICollection<Product> getProductByCondition = ShowClinteSiteProduct()
                                .Where(p => p.ConditionId == id).ToList();
            ViewBag.GetCondition = _iConditionManager.GetById(id);
            CommonComponent();
            return View(getProductByCondition);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            CommonComponent();
            return View();
        }

        [HttpGet]
        public IActionResult SearchProduct(string productname)
        {
            ICollection<Product> searchProducts = ShowClinteSiteProduct()
                .Where(p => p.Name.Contains(productname)).ToList();
            CommonComponent();
            return View(searchProducts);
        }

        [HttpPost]
        public IActionResult SearchProductByPrice(float? startprice, float? endprice)
        {
            if (startprice == null || endprice == null || startprice < 0 || endprice < 100)
                return RedirectToAction("Index");

            ICollection<Product> searchProductByPrice = ShowClinteSiteProduct()
                .Where(p => p.RegularPrice >= startprice && p.RegularPrice <= endprice ||
                p.OfferPrice >= startprice && p.OfferPrice <= endprice).ToList();

            CommonComponent();
            return View(searchProductByPrice);
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
