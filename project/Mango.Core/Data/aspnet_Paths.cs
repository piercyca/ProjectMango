namespace Mango.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_Paths
    {
        public aspnet_Paths()
        {
            aspnet_PersonalizationPerUser = new HashSet<aspnet_PersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }

        [Key]
        public Guid PathId { get; set; }

        [Required]
        [StringLength(256)]
        public string Path { get; set; }

        [Required]
        [StringLength(256)]
        public string LoweredPath { get; set; }

        public virtual aspnet_Applications aspnet_Applications { get; set; }

        public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers { get; set; }

        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
    }
}
