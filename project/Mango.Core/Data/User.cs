namespace Mango.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public Guid UserId { get; set; }

        public Guid ApplicationId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public bool IsAnonymous { get; set; }

        public DateTime LastActivityDate { get; set; }

        public virtual Application Application { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
