using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class DeliveryChargeManager : BaseManager<DeliveryCharge>, IDeliveryChargeManager
    {
        private readonly IDeliveryChargeRepository _iDeliveryChargeRepository;

        public DeliveryChargeManager(IDeliveryChargeRepository iDeliveryChargeRepository) : base(iDeliveryChargeRepository)
        {
            _iDeliveryChargeRepository = iDeliveryChargeRepository;
        }
    }
}
