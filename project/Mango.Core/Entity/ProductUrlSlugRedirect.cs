using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Core.Entity
{
    [Table("ProductUrlSlugRedirect")]
    public class ProductUrlSlugRedirect
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Key, Column(Order = 0)]
        public string OldUrlSlug { get; set; }

        /// <summary>
        /// Url to image
        /// </summary>
        [Required]
        public string NewUrlSlug { get; set; }
    }
}
