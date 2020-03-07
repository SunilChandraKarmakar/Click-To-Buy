using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager 
    {
        private readonly ICustomerRepository _iCustomerRepository;

        public CustomerManager(ICustomerRepository iCustomerRepository) : base(iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
        }

        public override ICollection<Customer> GetAll()
        {
            return _iCustomerRepository.GetAll();
        }

        public Customer CheckContact(string contact)
        {
            return _iCustomerRepository.CheckContact(contact);
        }

        public Customer CheckEmail(string email)
        {
            return _iCustomerRepository.CheckEmail(email);
        }
    }
}
