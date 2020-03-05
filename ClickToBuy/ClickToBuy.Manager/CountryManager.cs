using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CountryManager : BaseManager<Country>, ICountryManager
    {
        private readonly ICountryRepository _iCountryRepository;

        public CountryManager(ICountryRepository iCountryRepository) : base(iCountryRepository)
        {
            _iCountryRepository = iCountryRepository;
        }
    }
}
