using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface ICityManager : IBaseManager<City> 
    {
        public City CheckName(string name);
    }
}
