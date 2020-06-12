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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public override ICollection<OrderDetails> GetAll()
        {
            return ctbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .ToList();
        }
    }
}
