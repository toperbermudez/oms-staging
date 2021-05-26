using OMS.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OMS.Repository.Repositories
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        private readonly OMSContext _context;
        public CRUDRepository(OMSContext context)
        {
            _context = context;
        }

        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();

        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();
            return list;
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            return list;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking()
                .FirstOrDefault(where);
            return item;
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
