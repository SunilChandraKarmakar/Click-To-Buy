using ClickToBuy.Model;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public override Order GetById(int? id)
        {
            return ctbContext.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderDetails)
                    .Include(o => o.ReturnProducts)
                    .Include(o=>o.CustomerBillingAddress)
                    .Include(o => o.DeliveryCharge)
                    .Include(o => o.DeliveryCharge.City)
                    .Where(o => o.Id == id).FirstOrDefault();
        }

        public override ICollection<Order> GetAll()
        {
            return ctbContext.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderDetails)
                    .Include(o => o.ReturnProducts)
                    .Include(o => o.DeliveryCharge)
                    .ToList();
        }
    }
}
