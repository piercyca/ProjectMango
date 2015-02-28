using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="AddressService"/> to access <see cref="Address"/> entities
    /// </summary>
    public interface IAddressService
    {
        IEnumerable<Address> GetAddresss();
        Address GetAddress(int id);
        void CreateAddress(Address product);
        void EditAddress(Address product);
        void DeleteAddress(int id);
        void SaveAddress();
        IEnumerable<Address> SearchAddressesByName(string name);
    }

    /// <summary>
    /// Service to access <see cref="Address"/> entities
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepository"></param>
        /// <param name="unitOfWork"></param>
        public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetAddresss()
        {
            return _addressRepository.GetAll();
        }
        
        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address GetAddress(int id)
        {
            return _addressRepository.GetById(id);
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="product"></param>
        public void CreateAddress(Address product)
        {
            _addressRepository.Add(product);
            SaveAddress();
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="product"></param>
        public void EditAddress(Address product)
        {
            _addressRepository.Update(product);
            SaveAddress();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAddress(int id)
        {
            var product = _addressRepository.GetById(id);
            _addressRepository.Delete(product);
            SaveAddress();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveAddress()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Search address by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Address> SearchAddressesByName(string name)
        {
            return _addressRepository.GetMany(a => a.FirstName.ToLower().Contains(name.ToLower()) || a.LastName.ToLower().Contains(name.ToLower()))
        }
    }
}
