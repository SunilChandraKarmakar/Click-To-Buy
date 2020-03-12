using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IPurchaseManager : IBaseManager<Purchase> 
    {
        public List<Product> GetProductByCategory(int categoryId);
        public List<Product> GetProductByBrand(int brandId);
        public Purchase LastPurchaseInfo();
    }
}
