using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IAdminManager : IBaseManager<Admin> 
    {
        public Admin MatchLoginAdminDetails(string email, string password);
    }
}
