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
    public class CityRepository : BaseRepository<City>, ICityRepository 
    {
        public override ICollection<City> GetAll()
        {
            List<City> includeCityList = ctbContext.Cities.Include(c => c.Country).ToList();
            return includeCityList;
        }
    }
}
