using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class PurchaseItemManager : BaseManager<PurchaseItem>, IPurchaseItemManager 
    {
        private readonly IPurchaseItemRepository _iPurchaseItemRepository;

        public PurchaseItemManager(IPurchaseItemRepository iPurchaseItemRepository) : base(iPurchaseItemRepository)
        {
            _iPurchaseItemRepository = iPurchaseItemRepository;
        }
    }
}
