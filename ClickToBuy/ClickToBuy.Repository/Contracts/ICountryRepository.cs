﻿using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        public Country CheckName(string name);
    }
}
