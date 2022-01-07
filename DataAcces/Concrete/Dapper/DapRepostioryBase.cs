using DataAcces.Abstarct;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcces.Concrete.Dapper
{
    public class DapRepostioryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        public DapRepostioryBase(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity, bool save)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID, bool save)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public T GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(T entiy, bool save)
        {
            throw new NotImplementedException();
        }

    }
}
