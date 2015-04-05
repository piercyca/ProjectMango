using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="ProductUrlSlugRedirectRepository"/>
    /// </summary>
    public interface IProductUrlSlugRedirectRepository : IRepository<ProductUrlSlugRedirect>
    {

    }

    /// <summary>
    /// Product UrlSlugRedirect repository
    /// </summary>
    public class ProductUrlSlugRedirectRepository : RepositoryBase<ProductUrlSlugRedirect>, IProductUrlSlugRedirectRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseFactory"></param>
        public ProductUrlSlugRedirectRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
