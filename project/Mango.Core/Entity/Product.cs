using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Core.Entity
{
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Product Category Id
        /// </summary>
        [Required]
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Configuration should be a JSON string defining the setup of the <canvas></canvas>.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Canvas Image
        /// </summary>
        public string CanvasImage { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}