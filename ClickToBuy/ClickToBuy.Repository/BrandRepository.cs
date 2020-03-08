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
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository 
    {
        public override ICollection<Brand> GetAll()
        {
            List<Brand> brandList = ctbContext.Brands.Include(b => b.Products).ToList();
            return brandList;
        }

        public Brand CheckName(string name)
        {
            Brand checkName = ctbContext.Brands.Where(b => b.Name == name).FirstOrDefault();
            return checkName;
        }
    }
}
