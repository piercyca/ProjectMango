using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entities;

namespace Mango.Core.Infrastructure
{
    /// <summary>
    /// Unit of Work 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private MangoContext _dataContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseFactory"></param>
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Mango Context
        /// </summary>
        protected MangoContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        /// <summary>
        /// Commits transaction
        /// </summary>
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
