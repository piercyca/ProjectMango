using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entity;
using PagedList;

namespace Mango.Core.Infrastructure
{
    /// <summary>
    /// Respoistory Base class
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        private MangoContext dataContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected MangoContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        /// <summary>
        /// Delete entity (where)
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        /// <summary>
        /// Get entity by primary key (long)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// Get entity by primary key (string) 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// Get enumeration of entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        /// <summary>
        /// Get enumeration of entities (where)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <returns></returns>
        public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var results = dbset.OrderBy(order).Where(where).GetPage(page).ToList();
            var total = dbset.Count(where);
            return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
