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
            List<City> includeCityList = ctbContext.Cities
                                         .Include(c => c.Country)
                                         .Include(c => c.Customers)
                                         .ToList();
            return includeCityList;
        }

        public City CheckName(string name)
        {
            City checkName = ctbContext.Cities.Where(c => c.Name == name).FirstOrDefault();
            return checkName;
        }

        public List<Customer> CustomerList()
        {
            List<Customer> customerList = ctbContext.Customers.ToList();
            return customerList;
        }
    }
}
