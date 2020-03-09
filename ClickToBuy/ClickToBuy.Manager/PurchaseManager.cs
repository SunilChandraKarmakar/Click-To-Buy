using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class PurchaseManager : BaseManager<Purchase>, IPurchaseManager 
    {
        private readonly IPurchaseRepository _iPurchaseRepository;

        public PurchaseManager(IPurchaseRepository iPurchaseRepository) : base(iPurchaseRepository)
        {
            _iPurchaseRepository = iPurchaseRepository;
        }
    }
}
