using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CityManager : BaseManager<City>, ICityManager 
    {
        private readonly ICityRepository _iCityRepository;

        public CityManager(ICityRepository iCityRepository) : base(iCityRepository)
        {
            _iCityRepository = iCityRepository;
        }

        public override ICollection<City> GetAll()
        {
            return _iCityRepository.GetAll();
        }
    }
}
