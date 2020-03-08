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
    public class ProductRepository : BaseRepository<Product>, IProductRepository 
    {
        public override ICollection<Product> GetAll()
        {
            List<Product> productList = ctbContext.Products
                                        .Include(p => p.Brand)
                                        .Include(p => p.Category)
                                        .Include(p => p.CloseType)
                                        .Include(p => p.Condition).ToList();
            return productList;
        }

        public Product CheckName(string name)
        {
            Product existName = ctbContext.Products.Where(p => p.Name == name).FirstOrDefault();
            return existName;
        }
    }
}
