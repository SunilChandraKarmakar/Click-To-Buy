using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CustomerBillingAddressesManager : BaseManager<CustomerBillingAddress>, ICustomerBillingAddressesManager
    {
        private readonly ICustomerBillingAddressesRepository _iCustomerBillingAddressesRepository;

        public CustomerBillingAddressesManager(ICustomerBillingAddressesRepository iCustomerBillingAddressesRepository) : base(iCustomerBillingAddressesRepository)
        {
            _iCustomerBillingAddressesRepository = iCustomerBillingAddressesRepository;
        }
    }
}
