using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mango.Core.Common;

namespace Mango.Core.Entity
{
    [Table("ProductImage")]
    public class ProductImage
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        /// <summary>
        /// Sort Order
        /// </summary>
        [Key, Column(Order = 1)]
        public int SortOrder { get; set; }
        
        /// <summary>
        /// Url to image
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        /// <summary>
        /// Local Url to image
        /// </summary>
        [NotMapped]
        public string LocalUrl { get { return LocalBlobImageUrl.Url(Url); } }
    }
}
