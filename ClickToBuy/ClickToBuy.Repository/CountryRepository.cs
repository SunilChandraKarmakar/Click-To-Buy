using ClickToBuy.Model;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository 
    {
        public Country CheckName(string name)
        {
            Country checkName = ctbContext.Countries.Where(c => c.Name == name).FirstOrDefault();
            return checkName;
        }
    }
}
