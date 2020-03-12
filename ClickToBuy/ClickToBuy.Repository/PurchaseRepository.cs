using ClickToBuy.Model;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository 
    {
        public List<Product> GetProductByCategory(int categoryId)
        {
            List<Product> productByCategoryList = ctbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            return productByCategoryList;
        }

        public List<Product> GetProductByBrand(int brandId)
        {
            List<Product> productListByBrandId = ctbContext.Products.Where(p => p.BrandId == brandId).ToList();
            return productListByBrandId;
        }

        public Purchase LastPurchaseInfo()
        {
            string startPurchaseNumber = "100001";
            int convertIntstartPurchaseNumber = Convert.ToInt32(startPurchaseNumber);
            List<Purchase> purchases = ctbContext.Purchases.ToList();
            Purchase getLastPurchaseInfo = purchases.LastOrDefault();

            if (getLastPurchaseInfo != null)
            {
                string lastPurchaseNumber = getLastPurchaseInfo.PurchaseNumber;
                int convertIntlastPurchaseNumber = Convert.ToInt32(lastPurchaseNumber);
                int addNumber = convertIntlastPurchaseNumber + 1;
                getLastPurchaseInfo.PurchaseNumber = Convert.ToString(addNumber);
                return getLastPurchaseInfo;
            }
            else
            {
                Purchase generateFirstPurchaseNumber = new Purchase();
                generateFirstPurchaseNumber.PurchaseNumber = startPurchaseNumber;
                return generateFirstPurchaseNumber;
            }
        }
    }
}
