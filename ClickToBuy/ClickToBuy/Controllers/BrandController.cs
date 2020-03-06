using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandManager _iBrandManager;

        public BrandController(IBrandManager iBrandManager)
        {
            _iBrandManager = iBrandManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iBrandManager.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand aBrand)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iBrandManager.Add(aBrand);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Brand save has been failed!";
            }

            return View(aBrand);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Brand aBrand = _iBrandManager.GetById(id);

            if (aBrand == null)
                return NotFound();

            return View(aBrand);
        }

        [HttpPost]
        public IActionResult Update(Brand aBrand)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iBrandManager.Update(aBrand);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Brand update has been failed!";
            }

            return View(aBrand);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Brand aBrand = _iBrandManager.GetById(id);

            if (aBrand == null)
                return NotFound();

            return View(aBrand);
        }

        [HttpPost]
        public IActionResult Remove(Brand aBrand)
        {
            bool isRemove = _iBrandManager.Remove(aBrand);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Brand remove has been failed!";
        }
    }
}