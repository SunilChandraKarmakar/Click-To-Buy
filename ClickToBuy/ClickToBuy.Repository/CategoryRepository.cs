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
            List<Category> categoryList = ctbContext.Categories
                                          .Include(c => c.Categoryy).ToList();
            return categoryList;
        }
    }
}
