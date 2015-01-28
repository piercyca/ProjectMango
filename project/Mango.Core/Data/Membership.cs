namespace Mango.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Membership
    {
        [Key]
        public Guid UserId { get; set; }

        public Guid ApplicationId { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        public int PasswordFormat { get; set; }

        [Required]
        [StringLength(128)]
        public string PasswordSalt { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string PasswordQuestion { get; set; }

        [StringLength(128)]
        public string PasswordAnswer { get; set; }

        public bool IsApproved { get; set; }

        public bool IsLockedOut { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime LastPasswordChangedDate { get; set; }

        public DateTime LastLockoutDate { get; set; }

        public int FailedPasswordAttemptCount { get; set; }

        public DateTime FailedPasswordAttemptWindowStart { get; set; }

        public int FailedPasswordAnswerAttemptCount { get; set; }

        public DateTime FailedPasswordAnswerAttemptWindowsStart { get; set; }

        [StringLength(256)]
        public string Comment { get; set; }

        public virtual Application Application { get; set; }

        public virtual User User { get; set; }
    }
}
