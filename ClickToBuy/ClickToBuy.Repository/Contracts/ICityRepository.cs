using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface ICityRepository : IBaseRepository<City>
    {
        public City CheckName(string name);
        public List<Customer> CustomerList();
    }
}
