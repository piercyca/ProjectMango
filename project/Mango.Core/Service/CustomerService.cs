using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="CustomerService"/> to access <see cref="Customer"/> entities
    /// </summary>
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer GetCustomer(string username);
        void CreateCustomer(Customer customer);
        void EditCustomer(Customer customer);
        void DeleteCustomer(int id);
        void SaveCustomer();
        IEnumerable<Customer> SearchCustomerName(string name);
        IEnumerable<Customer> SearchCustomerEmail(string email);
        IEnumerable<Customer> GetCustomersByPage(int currentPage, int noOfRecords, string sortBy);
    }

    /// <summary>
    /// Service to access <see cref="Customer"/> entities
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="unitOfWork"></param>
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAll().OrderBy(p => p.LastName);
        }

        /// <summary>
        /// Returns a customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomer(string username)
        {
            return _customerRepository.Get(c => c.Username == username);
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="customer"></param>
        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            SaveCustomer();
        }

        /// <summary>
        /// Edit a customer
        /// </summary>
        /// <param name="customer"></param>
        public void EditCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            SaveCustomer();
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);
            SaveCustomer();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveCustomer()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Search customer by custom name. Checks first name and last name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Customer> SearchCustomerName(string name)
        {
            return _customerRepository.GetMany(c => c.FirstName.ToLower().Contains(name.ToLower()) || c.LastName.ToLower().Contains(name.ToLower())).OrderBy(c => c.LastName);
        }

        /// <summary>
        /// Search customer by custom email. Checks email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IEnumerable<Customer> SearchCustomerEmail(string email)
        {
            return _customerRepository.GetMany(c => c.Email.ToLower().Contains(email.ToLower())).OrderBy(c => c.Email);
        }

        /// <summary>
        /// Get customers by page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomersByPage(int currentPage, int noOfRecords, string sortBy)
        {
            return _customerRepository.GetCustomersByPage(currentPage, noOfRecords, sortBy);
        }
    }
}
