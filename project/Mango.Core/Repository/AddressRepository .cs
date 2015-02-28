using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="AddressRepository"/>
    /// </summary>
    public interface IAddressRepository : IRepository<Address>
    {
        /// <summary>
        /// Method will return products as different page with specified number of records ,filter condition and sort criteria
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<Address> SearchAddressesByName(string name);
    }

    /// <summary>
    /// Address repository
    /// </summary>
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        /// <summary>
        /// Search <see cref="Address"/> by name. Searches first name and last name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Address> SearchAddressesByName(string name)
        {
            var addresses = SearchAddressesByName(name);
            return addresses;
        }
    }
}
