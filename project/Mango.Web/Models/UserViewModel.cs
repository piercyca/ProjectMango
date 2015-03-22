using System;
using System.ComponentModel.DataAnnotations;
using Mango.Web.Models.Abstracts;


namespace Mango.Web.Models
{
    public class UserViewModel : ViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression(@"(^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$)", ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Display(Name = "Phone")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long.")]
        [RegularExpression(@"(\d{10})", ErrorMessage = "Phone number must be 10 digits numeric values.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Phone Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "Password Hash")]
        public string PasswordHash { get; set; }

        [Required]
        [Display(Name = "Security Stamp")]
        public string SecurityStamp { get; set; }

        [Required]
        [Display(Name = "Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "Lockout End Date UTC")]
        public DateTime? LockoutEndDateUtc { get; set; }

        [Required]
        [Display(Name = "Lockout Enabled")]
        public bool LockoutEnabled { get; set; }

        [Required]
        [Display(Name = "Access Failed Count")]
        public int AccessFailedCount { get; set; }
    }
}