using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Core.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
