namespace Mango.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Application
    {
        public Application()
        {
            Memberships = new HashSet<Membership>();
            Roles = new HashSet<Role>();
            Users = new HashSet<User>();
        }

        public Guid ApplicationId { get; set; }

        [Required]
        [StringLength(235)]
        public string ApplicationName { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
