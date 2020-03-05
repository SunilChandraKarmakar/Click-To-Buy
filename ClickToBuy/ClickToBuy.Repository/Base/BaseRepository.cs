using ClickToBuy.Database;
using ClickToBuy.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly CTBContext ctbContext;

        public BaseRepository()
        {
            ctbContext = new CTBContext();
        }

        public virtual T GetById(int? id)
        {
            return ctbContext.Set<T>().Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return ctbContext.Set<T>().ToList();
        }

        public virtual bool Add(T entity)
        {
            ctbContext.Set<T>().Add(entity);
            return ctbContext.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            ctbContext.Entry(entity).State = EntityState.Modified;
            return ctbContext.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            ctbContext.Set<T>().Remove(entity);
            return ctbContext.SaveChanges() > 0;
        }
    }
}
