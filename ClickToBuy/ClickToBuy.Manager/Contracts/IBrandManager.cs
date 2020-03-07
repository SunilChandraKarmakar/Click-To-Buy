using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IBrandManager : IBaseManager<Brand> 
    {
        public Brand CheckName(string name);
    }
}
