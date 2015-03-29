using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a Service to access Product Category entities
    /// </summary>
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetOrganizations();
        Organization GetOrganization(int id);
        void CreateOrganization(Organization organization);
        void EditOrganization(Organization organization);
        void DeleteOrganization(int id);
        void SaveOrganization();
        IEnumerable<Organization> SearchOrganization(string organizationName);
    }

    /// <summary>
    /// Service to access Product Category entities
    /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _organizationRepository.GetAll().OrderBy(pc => pc.Name);
        }

        /// <summary>
        /// Returns a product category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Organization GetOrganization(int id)
        {
            return _organizationRepository.GetById(id);
        }

        /// <summary>
        /// Creates a product category
        /// </summary>
        /// <param name="organization"></param>
        public void CreateOrganization(Organization organization)
        {
            _organizationRepository.Add(organization);
            SaveOrganization();
        }

        /// <summary>
        /// Edit a product category
        /// </summary>
        /// <param name="organization"></param>
        public void EditOrganization(Organization organization)
        {
            _organizationRepository.Update(organization);
            SaveOrganization();
        }

        /// <summary>
        /// Delete a product category
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrganization(int id)
        {
            var organization = _organizationRepository.GetById(id);
            _organizationRepository.Delete(organization);
            SaveOrganization();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveOrganization()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Search product category
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns></returns>
        public IEnumerable<Organization> SearchOrganization(string organizationName)
        {
            return _organizationRepository.GetMany(p => p.Name.ToLower().Contains(organizationName.ToLower())).OrderBy(p => p.Name);
        }
    }
}
