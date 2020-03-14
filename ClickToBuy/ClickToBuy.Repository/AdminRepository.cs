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
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository 
    {
        public override ICollection<Admin> GetAll()
        {
            List<Admin> adminList = ctbContext.Admins
                                    .Include(a => a.Country)
                                    .Include(a => a.City).ToList();
            return adminList;
        }
    }
}
