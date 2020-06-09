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
            ViewBag.ProductInfo = _iProductManager.GetById(id);
            CommonComponent();
            return View();
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
