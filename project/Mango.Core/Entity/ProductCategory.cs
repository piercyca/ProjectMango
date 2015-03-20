using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Core.Entity
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        [Index("IX_ProductCategory_UrlSlug", 1, IsUnique = true)]
        public string UrlSlug { get; set; }

        [Required]
        public string Keywords { get; set; }
    }
}