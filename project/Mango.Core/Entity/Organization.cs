using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Core.Entity
{
    [Table("Organization")]
    public class Organization
    {
        /// <summary>
        /// Organization Id
        /// </summary>
        [Key]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Primary Logo Image
        /// </summary>
        public string PrimaryLogoImage { get; set; }
    }
}
