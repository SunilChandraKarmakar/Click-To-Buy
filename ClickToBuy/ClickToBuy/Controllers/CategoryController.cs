using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                IPagedList<Category> categoryList = _iCategoryManager.GetAll()
                                                    .Where(c => c.Categoryy == null).ToList()
                                                    .ToPagedList(page ?? 1, 2);
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
            if(ModelState.IsValid)
            {
                Category addSubCategory = new Category()
                {
                    Name = subCategory,
                    CategoryId = aParentCategory.Id,
                    Description = aParentCategory.Description,
                    Status = aParentCategory.Status
                };

                bool isAddSubCategory = _iCategoryManager.Add(addSubCategory);

                if (isAddSubCategory)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Sub category add has been failed! Try again";
                    return View(aParentCategory);
                }
            }

            return View(aParentCategory);
        }

        [HttpGet]
        public IActionResult UpdateParentCategory(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category aCategory = _iCategoryManager.GetById(id);

                if (aCategory == null)
                    return NotFound();

                return View(aCategory);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult UpdateParentCategory(Category aParentCategoryCategory)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateParentCategory = _iCategoryManager.Update(aParentCategoryCategory);

                if (isUpdateParentCategory)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Parent category update has been failed! Try again.";
            }

            return View(aParentCategoryCategory);
        }

        [HttpGet]
        public IActionResult UpdateSubCategory(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category getSubCategory = _iCategoryManager.GetById(id);

                if (getSubCategory == null)
                    return NotFound();

                ViewBag.ParentCategory = CategoryList();
                return View(getSubCategory);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(Category aSubCategory)
        {
            if(ModelState.IsValid)
            {
                bool isUpdateSubCategory = _iCategoryManager.Update(aSubCategory);

                if (isUpdateSubCategory)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Sub category update has been failed! Try again.";
                    return View(aSubCategory);
                }
            }

            return View(aSubCategory);
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