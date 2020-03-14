using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class AdminManager : BaseManager<Admin>, IAdminManager 
    {
        private readonly IAdminRepository _iAdminRepository;

        public AdminManager(IAdminRepository iAdminRepository) : base(iAdminRepository)
        {
            _iAdminRepository = iAdminRepository;
        }

        public override ICollection<Admin> GetAll()
        {
            return _iAdminRepository.GetAll();
        }
    }
}
