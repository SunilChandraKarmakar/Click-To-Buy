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
                                          .Include(c => c.Categories).Include(c => c.Products).ToList();
            return categortList;
        }

        public Category CheckName(string name)
        {
            Category checkName = ctbContext.Categories.Where(c => c.Name == name).FirstOrDefault();
            return checkName;
        }
    }
}
