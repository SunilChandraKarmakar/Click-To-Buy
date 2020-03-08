using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class CloseTypeController : Controller
    {
        private readonly ICloseTypeManager _iCloseTypeManager;
        private readonly IProductManager _iProductManager;

        public CloseTypeController(ICloseTypeManager iCloseTypeManager, IProductManager iProductManager)
        {
            _iCloseTypeManager = iCloseTypeManager;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iCloseTypeManager.GetAll());
        }

        [HttpGet]
        public IActionResult GetProductByCloseType(int id)
        {
            List<Product> productList = _iProductManager.GetAll().Where(p => p.CloseTypeId == id).ToList();
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckName(string name)
        {
            CloseType existName = _iCloseTypeManager.GetAll().Where(c => c.Name == name).FirstOrDefault();

            if (existName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public IActionResult Create(CloseType aCloseType)
        {
            if (ModelState.IsValid)
            {
                bool isAdd = _iCloseTypeManager.Add(aCloseType);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Condition has been save to failed!";
            }

            return View(aCloseType);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            CloseType aCloseTypeDetails = _iCloseTypeManager.GetById(id);

            if (aCloseTypeDetails == null)
                return NotFound();

            return View(aCloseTypeDetails);
        }

        [HttpPost]
        public IActionResult Update(CloseType aCloseType)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _iCloseTypeManager.Update(aCloseType);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Condition has been update to failed!";
            }

            return View(aCloseType);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            CloseType aCloseTypeDetails = _iCloseTypeManager.GetById(id);

            if (aCloseTypeDetails == null)
                return NotFound();

            return View(aCloseTypeDetails);
        }

        [HttpPost]
        public IActionResult Remove(CloseType aCloseType)
        {
            bool isRemove = _iCloseTypeManager.Remove(aCloseType);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Condition remove to failed!";
        }
    }
}