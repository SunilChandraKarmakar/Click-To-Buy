using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IPurchaseRepository : IBaseRepository<Purchase> 
    {
        public List<Product> GetProductByCategory(int categoryId);
        public List<Product> GetProductByBrand(int brandId);
        public Purchase LastPurchaseInfo();
    }
}
