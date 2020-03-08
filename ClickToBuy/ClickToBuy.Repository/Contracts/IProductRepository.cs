using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IProductRepository : IBaseRepository<Product> 
    {
        public Product CheckName(string name);
    }
}
