using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class OrderManager : BaseManager<Order>, IOrderManager
    {
        private readonly IOrderRepository _iOrderRepository;
       
        public OrderManager(IOrderRepository iOrderRepository) : base(iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
        }
    }
}
