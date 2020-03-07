using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer> 
    {
        public Customer CheckContact(string contact);
        public Customer CheckEmail(string email);
    }
}
