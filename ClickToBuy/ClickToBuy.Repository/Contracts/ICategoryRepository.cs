﻿using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface ICategoryRepository : IBaseRepository<Category> 
    {
        public Category CheckName(string name);
        public ICollection<Category> GetCategoryForPurchaseProduct();
    }
}
