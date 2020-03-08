using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class BrandManager : BaseManager<Brand>, IBrandManager 
    {
        private readonly IBrandRepository _iBrandRepository;

        public BrandManager(IBrandRepository iBrandRepository) : base(iBrandRepository)
        {
            _iBrandRepository = iBrandRepository;
        }

        public override ICollection<Brand> GetAll()
        {
            return _iBrandRepository.GetAll();
        }

        public Brand CheckName(string name)
        {
            return _iBrandRepository.CheckName(name);
        }
    }
}
