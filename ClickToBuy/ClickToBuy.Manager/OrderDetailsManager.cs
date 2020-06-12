using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class OrderDetailsManager : BaseManager<OrderDetails>, IOrderDetailsManager
    {
        private readonly IOrderDetailsRepository _iOrderDetailsRepository;

        public OrderDetailsManager(IOrderDetailsRepository iOrderDetailsRepository) : base(iOrderDetailsRepository)
        {
            _iOrderDetailsRepository = iOrderDetailsRepository;
        }
    }
}
