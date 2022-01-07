using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcces.Abstarct
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        void Add(T entity, bool save);
        void Update(T entiy, bool save);
        void Delete(int ID, bool save);
        T GetByID(int ID);
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
