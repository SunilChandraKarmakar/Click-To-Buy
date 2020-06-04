﻿using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface ICategoryManager : IBaseManager<Category> 
    {
        public Category CheckName(string name);
        public ICollection<Category> GetCategoryForPurchaseProduct();
    }
}
