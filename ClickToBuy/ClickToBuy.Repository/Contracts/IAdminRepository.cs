using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        public Admin MatchLoginAdminDetails(string email, string password);
    }
}
