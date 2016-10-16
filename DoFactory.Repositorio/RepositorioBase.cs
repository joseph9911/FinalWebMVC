using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DoFactory.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        protected ContextoWebBD db;
        public RepositorioBase()
        {
            db = new ContextoWebBD();
        }
        public int Add(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> match)
        {
            return db.Set<T>().FirstOrDefault(match);
        }

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public IEnumerable<T> ListById(Expression<Func<T, bool>> match)
        {
            return db.Set<T>().Where(match);
        }

        public IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T, DateTime>> match, int size)
        {
            return db.Set<T>().OrderByDescending(match).Take(size);
        }

        public IEnumerable<T> PaginatedList(Expression<Func<T, int>> match, int page, int size)
        {
            return db.Set<T>().OrderByDescending(match).Page(page, size);
        }

        public int Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
