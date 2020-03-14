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
        private readonly ICategoryManager _iCategoryManager;
        private readonly IBrandManager _iBrandManager;
        private readonly IConditionManager _iConditionManager;
        private readonly ICloseTypeManager _iCloseTypeManager;
        private readonly IStockProductManager _iStockProductManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public ProductController(IProductManager iProductManager,
                                ICategoryManager iCategoryManager,
                                IBrandManager iBrandManager,
                                IConditionManager iConditionManager,
                                ICloseTypeManager iCloseTypeManager, 
                                IHostingEnvironment iHostingEnvironment, IStockProductManager iStockProductManager)
        {
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iBrandManager = iBrandManager;
            _iConditionManager = iConditionManager;
            _iCloseTypeManager = iCloseTypeManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iStockProductManager = iStockProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.StockProductList = _iStockProductManager.GetAll();
            return View(_iProductManager.GetAll());
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
            List<StockProduct> stockProducts = _iStockProductManager.GetAll().Where(s => s.ProductId == id).ToList();
            return View(stockProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = CategoryList();
            ViewBag.BrandList = BrandList();
            ViewBag.ConditionList = ConditionList();
            ViewBag.CloseTypeList = CloseTypeList();
            return View();
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
        public IActionResult Create(Product aProduct, IFormFile picture)
        {
            if(ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/ProductPicture",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aProduct.Picture = "ProductPicture/" + picture.FileName;
                }

                if (picture == null)
                    aProduct.Picture = "ProductPicture/NoImageFound.png";

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

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Product aProduct, IFormFile picture, string pic)
        {
            if(ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/ProductPicture",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aProduct.Picture = "ProductPicture/" + picture.FileName;
                }

                if (picture == null)
                    aProduct.Picture = pic;

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