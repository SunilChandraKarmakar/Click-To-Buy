using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IPurchaseItemRepository : IBaseRepository<PurchaseItem> 
    {
        public ICollection<PurchaseItem> GetPurchaseItemByPurchaseId(int id);
    }
}
