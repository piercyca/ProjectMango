using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Core.Entity
{
    [Table("OrganizationImage")]
    public class OrganizationImage
    {
        /// <summary>
        /// Organization Id
        /// </summary>
        [Key, Column(Order = 0)]
        public int OrganizationId { get; set; }

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
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
    }
}
