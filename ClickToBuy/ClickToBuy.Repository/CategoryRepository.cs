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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository 
    {
        public override ICollection<Category> GetAll()
        {
            List<Category> categortList = ctbContext.Categories
                                          .Include(c=>c.Categoryy)
                                          .Include(c => c.Categories)
                                          .Include(c => c.Products)
                                          .ToList();
            return categortList;
        }

        public Category CheckName(string name)
        {
            Category checkName = ctbContext.Categories.Where(c => c.Name == name).FirstOrDefault();
            return checkName;
        }

        public ICollection<Category> GetCategoryForPurchaseProduct()
        {
            List<PurchaseItem> purchaseItems = ctbContext.PurchaseItems.ToList();
            List<Product> products = new List<Product>();

            foreach (PurchaseItem item in purchaseItems)
            {
                Product aProductInfo = ctbContext.Products
                        .Include(p => p.Category).Where(p => p.Id == item.ProductId).FirstOrDefault();
                products.Add(aProductInfo);
            }

            products = products.Distinct().ToList();
            List<Category> categories = new List<Category>();

            foreach (Product item in products)
            {
                Category category = ctbContext.Categories.Include(c=>c.Categories).Include(c=>c.Categoryy)
                                    .Where(c => c.Id == item.CategoryId).FirstOrDefault();
                categories.Add(category);
            }

            categories = categories.Distinct().ToList();
            return categories;
        }
    }
}
