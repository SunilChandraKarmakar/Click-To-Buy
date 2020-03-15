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
    public class ConditionController : Controller
    {
        private readonly IConditionManager _iConditionManager;
        private readonly IProductManager _iProductManager;

        public ConditionController(IConditionManager iConditionManager, IProductManager iProductManager)
        {
            _iConditionManager = iConditionManager;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iConditionManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult GetProductByCondition(int id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                List<Product> productList = _iProductManager.GetAll().Where(p => p.ConditionId == id).ToList();
                return View(productList);
            }
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
        public JsonResult CheckName(string name)
        {
            Condition existName = _iConditionManager.GetAll().Where(c => c.Name == name).FirstOrDefault();

            if (existName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public IActionResult Create(Condition aCondition)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iConditionManager.Add(aCondition);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Condition has been save to failed!";
            }

            return View(aCondition);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Condition aConditionDetails = _iConditionManager.GetById(id);

                if (aConditionDetails == null)
                    return NotFound();

                return View(aConditionDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(Condition aCondition)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iConditionManager.Update(aCondition);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Condition has been update to failed!";
            }

            return View(aCondition);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Condition aConditionDetails = _iConditionManager.GetById(id);

                if (aConditionDetails == null)
                    return NotFound();

                return View(aConditionDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Condition aCondition)
        {
            bool isRemove = _iConditionManager.Remove(aCondition);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Condition remove to failed!";
        }
    }
}