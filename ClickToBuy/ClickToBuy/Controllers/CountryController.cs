using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryManager _iCountryManager;

        public CountryController(ICountryManager iCountryManager)
        {
            _iCountryManager = iCountryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iCountryManager.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckName(string name)
        {
            Country checkName = _iCountryManager.CheckName(name);

            if (checkName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public IActionResult Create(Country aCountry)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iCountryManager.Add(aCountry);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Country save has been failed!";
            }

            return View(aCountry);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Country aCountry = _iCountryManager.GetById(id);

            if (aCountry == null)
                return NotFound();

            return View(aCountry);
        }

        [HttpPost]
        public IActionResult Update(Country aCountry)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iCountryManager.Update(aCountry);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Country update has been failed!";
            }

            return View(aCountry);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Country aCountry = _iCountryManager.GetById(id);

            if (aCountry == null)
                return NotFound();

            return View(aCountry);
        }

        [HttpPost]
        public IActionResult Remove(Country aCountry)
        {
            bool isDelete = _iCountryManager.Remove(aCountry);

            if (isDelete)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Country delete has been failed!";
        }
    }
}