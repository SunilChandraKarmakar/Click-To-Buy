using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ClickToBuy.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IBrandManager _iBrandManager;
        private readonly IConditionManager _iConditionManager;
        private readonly ICloseTypeManager _iCloseTypeManager;
        private readonly IStockProductManager _iStockProductManager;
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IOrderDetailsManager _iOrderDetailsManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public ProductController(IProductManager iProductManager,
                                ICategoryManager iCategoryManager,
                                IBrandManager iBrandManager,
                                IConditionManager iConditionManager,
                                ICloseTypeManager iCloseTypeManager, 
                                IHostingEnvironment iHostingEnvironment, 
                                IStockProductManager iStockProductManager, 
                                IProductPhotoManager iProductPhotoManager, 
                                IPurchaseItemManager iPurchaseItemManager, IOrderDetailsManager iOrderDetailsManager)
        {
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iBrandManager = iBrandManager;
            _iConditionManager = iConditionManager;
            _iCloseTypeManager = iCloseTypeManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iStockProductManager = iStockProductManager;
            _iProductPhotoManager = iProductPhotoManager;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iOrderDetailsManager = iOrderDetailsManager;
        }

        private List<SelectListItem> CategoryList()
        {
            List<SelectListItem> categoryList = _iCategoryManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                }).ToList();
            return categoryList;
        }

        private List<SelectListItem> BrandList()
        {
            List<SelectListItem> brandList = _iBrandManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                }).ToList();
            return brandList;
        }

        private List<SelectListItem> ConditionList()
        {
            List<SelectListItem> conditionList = _iConditionManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                }).ToList();
            return conditionList;
        }

        private List<SelectListItem> CloseTypeList()
        {
            List<SelectListItem> closeTypeList = _iCloseTypeManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                }).ToList();
            return closeTypeList;
        }

        private void CommonComponent()
        {
            ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();
            ViewBag.StockProductList = _iStockProductManager.GetAll();
            ViewBag.PurchaseItems = _iPurchaseItemManager.GetAll();
            ViewBag.OrderDetails = _iOrderDetailsManager.GetAll();
            ViewBag.Brands = BrandList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.ConditionList = ConditionList();
            ViewBag.CloseTypeList = CloseTypeList();
            ViewBag.Categorys = _iCategoryManager.GetAll().Where(c => c.Categoryy == null).ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                CommonComponent();                  
                return View(_iProductManager.GetAll());
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult GetStockByProduct(int id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                List<StockProduct> stockProducts = _iStockProductManager.GetAll().Where(s => s.ProductId == id).ToList();
                return View(stockProducts);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                CommonComponent();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckName(string name)
        {
            Product checkName = _iProductManager.CheckName(name);

            if (checkName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Product aProduct)
        {
            if(ModelState.IsValid)
            {   
                bool isAdd = _iProductManager.Add(aProduct);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Product save has been failed!";
            }

            CommonComponent();
            return View(aProduct);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Product aProductDetails = _iProductManager.GetById(id);

                if (aProductDetails == null)
                    return NotFound();

                CommonComponent();
                return View(aProductDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Product aProduct)
        {
            if(ModelState.IsValid)
            {   
                bool isUpdate = _iProductManager.Update(aProduct);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Product update has been failed!";
            }

            CommonComponent();
            return View(aProduct);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Product aProductDetails = _iProductManager.GetAll().Where(p => p.Id == id).FirstOrDefault();

                if (aProductDetails == null)
                    return NotFound();

                CommonComponent();
                return View(aProductDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Product aProduct)
        {
            bool isRemove = _iProductManager.Remove(aProduct);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Product remove has been failed!";
        }

        [HttpPost]
        public IActionResult SPCategoryOrBrand(int? categoryId, int? brandId)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if(categoryId != null && brandId != null)
                {                       
                    return RedirectToAction("CategoryAndBrandProducts", new { categoryId = categoryId, brandId = brandId});
                }

                if (categoryId != null && brandId == null)
                    return RedirectToAction("GetProductByCategory", new { categoryId = categoryId });

                if (categoryId == null && brandId != null)
                    return RedirectToAction("GetProductByBrand", new { brandId = brandId });

                return RedirectToAction("Index");
            }
            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult CategoryAndBrandProducts(int categoryId, int brandId)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                List<Product> getProductByCategoryAndBrand = _iProductManager.GetAll()
                .Where(p => p.CategoryId == categoryId && p.BrandId == brandId).ToList();

                CommonComponent();
                return View(getProductByCategoryAndBrand);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult GetProductByCategory(int categoryId)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                CommonComponent();
                return View(_iProductManager.GetAll().Where(p => p.CategoryId == categoryId).ToList());
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult GetProductByBrand(int brandId)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                CommonComponent();
                return View(_iProductManager.GetAll().Where(p => p.BrandId == brandId).ToList());
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult SearchProductByPrice(float startPrice, float endPrice)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                CommonComponent();
                return View(_iProductManager.GetAll().Where(p => p.RegularPrice >= startPrice &&
                p.RegularPrice <= endPrice).ToList());
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}