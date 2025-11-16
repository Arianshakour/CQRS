using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShopContext _db;
        public GenericRepository(ShopContext shopContext)
        {
            _db = shopContext;
        }
        public void Create(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            _db.SaveChanges();
        }

        public TEntity Get(int id)
        {
            var enty = _db.Set<TEntity>().Find(id);
            //if (enty == null)
            //    throw new NullReferenceException();
            return enty;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public void update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            _db.SaveChanges();
        }
    }
}
