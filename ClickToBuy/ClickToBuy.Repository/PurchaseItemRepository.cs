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
    public class PurchaseItemRepository : BaseRepository<PurchaseItem>, IPurchaseItemRepository 
    {
        public ICollection<PurchaseItem> GetPurchaseItemByPurchaseId(int id)
        {
            List<PurchaseItem> purchaseItemList = ctbContext.PurchaseItems
                                                  .Include(p=>p.Product)
                                                  .Where(p => p.Purchase.Id == id).ToList();
            return purchaseItemList;
        }
    }
}
