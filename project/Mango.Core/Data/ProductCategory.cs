using System;
using System.ComponentModel.DataAnnotations;

namespace Mango.Core.Data
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
