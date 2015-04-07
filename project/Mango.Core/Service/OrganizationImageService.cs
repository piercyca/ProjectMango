using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;
using Newtonsoft.Json;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="OrganizationImageService"/> to access <see cref="OrganizationImage"/> entities
    /// </summary>
    public interface IOrganizationImageService
    {
        OrganizationImage GetOrganizationImage(int organizationId, int sortOrder);
        void DeleteOrganizationImages(int organizationId);
        void InsertOrganizationImages(int organizationId, string urls);
        IEnumerable<OrganizationImage> GetOrganizationImages(int organizationId);
    }

    /// <summary>
    /// Service to access <see cref="OrganizationImage"/> entities
    /// </summary>
    public class OrganizationImageService : IOrganizationImageService
    {
        private readonly IOrganizationImageRepository _organizationImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="organizationImageRepository"></param>
        /// <param name="unitOfWork"></param>
        public OrganizationImageService(IOrganizationImageRepository organizationImageRepository, IUnitOfWork unitOfWork)
        {
            _organizationImageRepository = organizationImageRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveOrganizationImage()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Get a Organization Image
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public OrganizationImage GetOrganizationImage(int organizationId, int sortOrder)
        {
            return _organizationImageRepository.GetOrganizationImage(organizationId, sortOrder);
        }

        /// <summary>
        /// Deletes Organization Images
        /// </summary>
        /// <param name="organizationId"></param>
        public void DeleteOrganizationImages(int organizationId)
        {
            var organizationImages = _organizationImageRepository.GetOrganizationImages(organizationId);
            foreach (var organizationImage in organizationImages)
            {
                _organizationImageRepository.Delete(organizationImage);
            }
            SaveOrganizationImage();
        }

        /// <summary>
        /// Inserts organization image(s)
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="urls"></param>
        public void InsertOrganizationImages(int organizationId, string urls)
        {
            // delete first, prevents sort conflicts from existing data
            DeleteOrganizationImages(organizationId);
            // save the updated records
            var urlList = JsonConvert.DeserializeObject<object[]>(urls);
            for (int i = 0; i < urlList.Length; i++)
            {
                _organizationImageRepository.Add(new OrganizationImage
                {
                    OrganizationId = organizationId,
                    Url = urlList[i].ToString(),
                    SortOrder = i
                });
            }
            // Save changes
            SaveOrganizationImage();
        }

        public IEnumerable<OrganizationImage> GetOrganizationImages(int organizationId)
        {
            return _organizationImageRepository.GetOrganizationImages(organizationId).OrderBy(pi => pi.SortOrder);
        }
    }
}
