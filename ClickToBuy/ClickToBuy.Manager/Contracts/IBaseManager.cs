﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager.Contracts
{
    public interface IBaseManager<T> where T : class
    {
        public T GetById(int? id);
        public ICollection<T> GetAll();
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Remove(T entity);
    }
}
