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
    public class CustomerOrder : Controller
    {
        private readonly IOrderManager _iOrderManager;
        private readonly IOrderDetailsManager _iOrderDetailsManager;
        private readonly ICustomerBillingAddressesManager _iCustomerBillingAddressesManager;

        public CustomerOrder(IOrderManager iOrderManager, IOrderDetailsManager iOrderDetailsManager,
            ICustomerBillingAddressesManager iCustomerBillingAddressesManager)
        {
            _iOrderManager = iOrderManager;
            _iOrderDetailsManager = iOrderDetailsManager;
            _iCustomerBillingAddressesManager = iCustomerBillingAddressesManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                return View(_iOrderManager.GetAll());    
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult OrderDetails(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Order customerOrderInfo = _iOrderManager.GetById(id);
                ICollection<OrderDetails> customerOrderDetails = _iOrderDetailsManager.GetAll()
                    .Where(od => od.OrderId == id).ToList();
                CustomerBillingAddress customerOrderBillingAddress = _iCustomerBillingAddressesManager
                    .GetAll().Where(coba => coba.CustomerId == customerOrderInfo.CustomerId).LastOrDefault();

                if (customerOrderDetails == null)
                    customerOrderDetails = new List<OrderDetails>();

                ViewBag.CustomerOrderBillingAddress = customerOrderBillingAddress;
                ViewBag.CustomerOrderInfo = customerOrderInfo;
                return View(customerOrderDetails);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult AcceptOrder(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Order selectedOrderDetails = _iOrderManager.GetById(id);

                if (selectedOrderDetails == null)
                    return NotFound();

                selectedOrderDetails.Status = true;
                bool isUpdate = _iOrderManager.Update(selectedOrderDetails);

                if (isUpdate)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult SearchOrder(DateTime from, DateTime to)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<Order> customerOrder = _iOrderManager.GetAll()
                    .Where(o => o.OrderDate >= from && o.OrderDate <= to).ToList();
                return View(customerOrder);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}
