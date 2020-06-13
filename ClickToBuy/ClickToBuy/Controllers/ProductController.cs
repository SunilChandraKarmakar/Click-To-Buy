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
                                IProductPhotoManager iProductPhotoManager, IPurchaseItemManager iPurchaseItemManager)
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
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();
                ViewBag.StockProductList = _iStockProductManager.GetAll();
                ViewBag.PurchaseItems = _iPurchaseItemManager.GetAll();
                return View(_iProductManager.GetAll());
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
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
                ViewBag.CategoryList = CategoryList();
                ViewBag.BrandList = BrandList();
                ViewBag.ConditionList = ConditionList();
                ViewBag.CloseTypeList = CloseTypeList();
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

            ViewBag.CategoryList = CategoryList();
            ViewBag.BrandList = BrandList();
            ViewBag.ConditionList = ConditionList();
            ViewBag.CloseTypeList = CloseTypeList();
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

                ViewBag.CategoryList = CategoryList();
                ViewBag.BrandList = BrandList();
                ViewBag.ConditionList = ConditionList();
                ViewBag.CloseTypeList = CloseTypeList();
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

            ViewBag.CategoryList = CategoryList();
            ViewBag.BrandList = BrandList();
            ViewBag.ConditionList = ConditionList();
            ViewBag.CloseTypeList = CloseTypeList();
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

                ViewBag.CategoryList = CategoryList();
                ViewBag.BrandList = BrandList();
                ViewBag.ConditionList = ConditionList();
                ViewBag.CloseTypeList = CloseTypeList();
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
    }
}