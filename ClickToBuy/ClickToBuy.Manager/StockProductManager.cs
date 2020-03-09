using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class StockProductManager : BaseManager<StockProduct>, IStockProductManager 
    {
        private readonly IStockProductRepository _iStockProductRepository;

        public StockProductManager(IStockProductRepository iStockProductRepository) : base(iStockProductRepository)
        {
            _iStockProductRepository = iStockProductRepository;
        }

        public override ICollection<StockProduct> GetAll()
        {
            return _iStockProductRepository.GetAll();
        }

        public ICollection<NonProductInStock> GetAllProductNotInStock()
        {
            return _iStockProductRepository.GetAllProductNotInStock();
        }
    }
}
