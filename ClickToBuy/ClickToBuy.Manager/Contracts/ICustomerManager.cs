using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface ICustomerManager : IBaseManager<Customer> 
    {
        public Customer CheckContact(string contact);
        public Customer CheckEmail(string email);
    }
}
