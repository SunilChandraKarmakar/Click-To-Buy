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

        public override ICollection<Purchase> GetAll()
        {
            return _iPurchaseRepository.GetAll();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _iPurchaseRepository.GetProductByCategory(categoryId);
        }

        public List<Product> GetProductByBrand(int brandId)
        {
            return _iPurchaseRepository.GetProductByBrand(brandId);
        }

        public Purchase LastPurchaseInfo()
        {
            return _iPurchaseRepository.LastPurchaseInfo();
        }
    }
}
