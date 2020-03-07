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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository 
    {
        public override ICollection<Customer> GetAll()
        {
            return ctbContext.Customers
                             .Include(c => c.Country)
                             .Include(c => c.City)
                             .Include(c => c.Gender).ToList();
        }

        public Customer CheckContact(string contact)
        {
            Customer checkContact = ctbContext.Customers.Where(c => c.Contact == contact).FirstOrDefault();
            return checkContact;
        }

        public Customer CheckEmail(string email)
        {
            Customer checkEmail = ctbContext.Customers.Where(c => c.Email == email).FirstOrDefault();
            return checkEmail;
        }
    }
}
