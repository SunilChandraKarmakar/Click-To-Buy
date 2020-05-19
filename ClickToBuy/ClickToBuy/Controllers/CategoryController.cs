using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductManager _iProductManager;

        public CategoryController(ICategoryManager iCategoryManager, IProductManager iProductManager)
        {
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<Category> categoryList = _iCategoryManager.GetAll()
                                                    .Where(c => c.Categoryy == null).ToList();
                return View(categoryList);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult GetProductByCategoryId(int id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                List<Product> productList = _iProductManager.GetAll().Where(p => p.CategoryId == id).ToList();
                return View(productList);
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

        [HttpGet]
        public IActionResult AddParentCategory()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View();
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckName(string name)
        {
            Category checkName = _iCategoryManager.CheckName(name);

            if (checkName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public IActionResult AddParentCategory(Category aParentCategory)
        {                                               
            if(ModelState.IsValid)
            {
                bool isAddParentCategory = _iCategoryManager.Add(aParentCategory);

                if (isAddParentCategory)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Parent category save has been failed! Try again.";
            }

            return View(aParentCategory);
        }

        [HttpGet]
        public IActionResult AddSubCategory(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category getParemtCategoryInfo = _iCategoryManager.GetById(id);

                if (getParemtCategoryInfo == null)
                    return NotFound();

                return View(getParemtCategoryInfo);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult AddSubCategory(Category aParentCategory, string subCategory)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category aCategory = _iCategoryManager.GetById(id);

                if (aCategory == null)
                    return NotFound();

                ViewBag.CategoryList = CategoryList();
                return View(aCategory);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(Category aCategory)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _iCategoryManager.Update(aCategory);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Category update has been failed!";
            }

            ViewBag.CountryList = CategoryList();
            return View(aCategory);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category aCategory = _iCategoryManager.GetById(id);

                if (aCategory == null)
                    return NotFound();

                ViewBag.CategoryList = CategoryList();
                return View(aCategory);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Category aCategory)
        {
            bool isRemove = _iCategoryManager.Remove(aCategory);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Category remove has been failed!";
        }
    }
}