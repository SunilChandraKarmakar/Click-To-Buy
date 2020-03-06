﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _iCategoryManager;

        public CategoryController(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iCategoryManager.GetAll());
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
        public IActionResult Create()
        {
            ViewBag.CategoryList = CategoryList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category aCategory)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iCategoryManager.Add(aCategory);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Category save has been failed!";
            }

            ViewBag.CategoryList = CategoryList();
            return View(aCategory);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Category aCategory = _iCategoryManager.GetById(id);

            if (aCategory == null)
                return NotFound();

            ViewBag.CategoryList = CategoryList();
            return View(aCategory);
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
            if (id == null)
                return NotFound();

            Category aCategory = _iCategoryManager.GetById(id);

            if (aCategory == null)
                return NotFound();

            ViewBag.CategoryList = CategoryList();
            return View(aCategory);
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