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
    public class CustomerBillingAddressesRepository : BaseRepository<CustomerBillingAddress>, ICustomerBillingAddressesRepository
    {
        public override ICollection<CustomerBillingAddress> GetAll()
        {
            return ctbContext.CustomerBillingAddresses
                .Include(cba => cba.Customer.City).ToList();                    
        }
    }
}
