namespace Mango.Core.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class ProductCategory
    {
        public Guid ProductCategoryId { get; set; }

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
