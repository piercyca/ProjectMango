using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="OrganizationRepository"/>
    /// </summary>
    public interface IOrganizationRepository : IRepository<Organization>
    {
        /// <summary>
        /// Method will return organizations 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Organization> GetProductCategories();
    }

    /// <summary>
    /// Product Category repository
    /// </summary>
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Organization> GetProductCategories()
        {
            var productCategories = GetAll();
            return productCategories;
        }
    }
}
