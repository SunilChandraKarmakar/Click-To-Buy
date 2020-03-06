using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class GenderManager : BaseManager<Gender>, IGenderManager
    {
        private readonly IGenderRepository _iGenderRepository;

        public GenderManager(IGenderRepository iGenderRepository) : base(iGenderRepository)
        {
            _iGenderRepository = iGenderRepository;
        }
    }
}
