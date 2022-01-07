using DataAcces.Abstarct;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAcces.Concrete
{
    public class EfRepostioryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        public EfRepostioryBase(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The save parameter gets for unity of work design's Save Changes method in Add-Update-Delete methods.
        /// If you aren't save changes, these methods save changes. Thus ,You don't need save changes into unity of work class.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        public virtual void  Add(T entity, bool save = true)
        {
            _context.Set<T>().Add(entity);
            if (save) _context.SaveChanges();
        }
        public virtual void Delete(int ID, bool save = true)
        {
            _context.Set<T>().Remove(GetByID(ID));
            if (save) _context.SaveChanges();
        }
        public virtual ICollection<T> GetAll(Expression<Func<T,bool>> filter = null)
            =>  (filter == null)
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        public virtual T GetByID(int ID)
        {
           return  _context.Set<T>().Find(ID);
        }
        public virtual void Update(T entity, bool save = true)
        {
            _context.Set<T>().Update(entity);
            if (save) _context.SaveChanges();
        }
    }
}
