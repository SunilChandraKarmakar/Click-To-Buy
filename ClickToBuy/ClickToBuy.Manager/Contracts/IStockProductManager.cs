using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IStockProductManager : IBaseManager<StockProduct> 
    {
        public ICollection<NonProductInStock> GetAllProductNotInStock();
    }
}
