using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Core.Data
{
    public class ProductConfig
    {
        [Key]
        public int ProductConfigId { get; set; }

        [Required]
        [Index]
        public int ProductId { get; set; }

        /// <summary>
        /// Version allows configs to be updated without breaking products 
        /// already created. Should increment by 1.
        /// </summary>
        [Required]
        [Index]
        public int Version { get; set; }

        /// <summary>
        /// Configuration should be a JSON string defining the setup of the <canvas></canvas>.
        /// </summary>
        [Required]
        public string Configuration { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("ProductId")] 
        public Product Product { get; set; }

        public ProductConfig()
        {
            Created = DateTime.UtcNow;
        }
    }
}