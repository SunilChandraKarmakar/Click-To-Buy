using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository
{
    public class StockProductRepository : BaseRepository<StockProduct>, IStockProductRepository 
    {
        public override ICollection<StockProduct> GetAll()
        {
            List<StockProduct> stockProductList = ctbContext.StockProducts.Include(s => s.Product).ToList();
            return stockProductList;
        }

        [Obsolete]
        public ICollection<NonProductInStock> GetAllProductNotInStock()
        {
            return ctbContext.NonProductInStocks.ToList();
        }
    }
}
