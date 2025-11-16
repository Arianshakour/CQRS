using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Create(TEntity entity);
        void update(TEntity entity);
        void Delete(TEntity entity);
    }
}
