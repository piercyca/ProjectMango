using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="OrganizationImageRepository"/>
    /// </summary>
    public interface IOrganizationImageRepository : IRepository<OrganizationImage>
    {
        /// <summary>
        /// Method will return organization images for a organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        IEnumerable<OrganizationImage> GetOrganizationImages(int organizationId);

        /// <summary>
        /// Gets a organization image
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        OrganizationImage GetOrganizationImage(int organizationId, int sortOrder);
    }

    /// <summary>
    /// Organization Image repository
    /// </summary>
    public class OrganizationImageRepository : RepositoryBase<OrganizationImage>, IOrganizationImageRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseFactory"></param>
        public OrganizationImageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        /// <summary>
        /// Gets the organization images for a organization and sorts by SortOrder
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public IEnumerable<OrganizationImage> GetOrganizationImages(int organizationId)
        {
            return GetAll().Where(pi => pi.OrganizationId == organizationId).OrderBy(pi => pi.SortOrder);
        }

        /// <summary>
        /// Gets a organization image
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public OrganizationImage GetOrganizationImage(int organizationId, int sortOrder)
        {
            return Get(pi => pi.OrganizationId == organizationId && pi.SortOrder == sortOrder);
        }
    }
}
