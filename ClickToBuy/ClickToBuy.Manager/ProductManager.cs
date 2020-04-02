using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class ProductManager : BaseManager<Product>, IProductManager 
    {
        private readonly IProductRepository _iProductRepository;

        public ProductManager(IProductRepository iProductRepository) : base(iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public override ICollection<Product> GetAll()
        {
            return _iProductRepository.GetAll();
        }

        public override Product GetById(int? id)
        {
            return _iProductRepository.GetById(id);
        }

        public Product CheckName(string name)
        {
            return _iProductRepository.CheckName(name);
        }
    }
}
