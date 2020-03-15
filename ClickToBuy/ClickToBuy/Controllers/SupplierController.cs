using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierManager _iSupplierManager;

        public SupplierController(ISupplierManager iSupplierManager)
        {
            _iSupplierManager = iSupplierManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iSupplierManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(); 
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckEmail(string email)
        {
            Supplier aSupplierDetails = _iSupplierManager.GetAll().Where(s => s.Email == email).FirstOrDefault();

            if (aSupplierDetails != null)
                return Json(1);
            else
                return Json(0);
            
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckContactNo(string contactNo)
        {
            Supplier aSupplierDetails = _iSupplierManager.GetAll().Where(s => s.ContactNo == contactNo).FirstOrDefault();

            if (aSupplierDetails != null)
                return Json(1);
            else
                return Json(0);

        }

        [HttpPost]
        public IActionResult Create(Supplier aSupplier)
        {
            if (ModelState.IsValid)
            {
                bool isAdd = _iSupplierManager.Add(aSupplier);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Supplier save has been failed!";
            }

            return View(aSupplier);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Supplier aSupplier = _iSupplierManager.GetById(id);

                if (aSupplier == null)
                    return NotFound();

                return View(aSupplier);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(Supplier aSupplier)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _iSupplierManager.Update(aSupplier);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Supplier update has been failed!";
            }

            return View(aSupplier);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Supplier aSupplier = _iSupplierManager.GetById(id);

                if (aSupplier == null)
                    return NotFound();

                return View(aSupplier);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Supplier aSupplier)
        {
            bool isRemove = _iSupplierManager.Remove(aSupplier);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Supplier remove has been failed!";
        }
    }
}