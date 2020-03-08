using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CloseTypeManager : BaseManager<CloseType>, ICloseTypeManager 
    {
        private readonly ICloseTypeRepository _iCloseTypeRepository;

        public CloseTypeManager(ICloseTypeRepository iCloseTypeRepository) : base(iCloseTypeRepository)
        {
            _iCloseTypeRepository = iCloseTypeRepository;
        }

        public override ICollection<CloseType> GetAll()
        {
            return _iCloseTypeRepository.GetAll();
        }
    }
}
