namespace Mango.Core.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
