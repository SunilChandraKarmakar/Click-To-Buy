using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IProductManager : IBaseManager<Product> 
    {
        public Product CheckName(string name);
    }
}
