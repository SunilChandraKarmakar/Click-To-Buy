using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IStockProductRepository : IBaseRepository<StockProduct> 
    {
        public ICollection<NonProductInStock> GetAllProductNotInStock(); 
    }
}
