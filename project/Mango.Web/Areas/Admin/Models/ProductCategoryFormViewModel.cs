using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Mango.Core.Entity;
using Mango.Core.Web.CustomValidators;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="ProductCategory" />
    /// </summary>
    public class ProductCategoryFormViewModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [UniqueValidator("ProductCategoryId", UniqueValidatorType.ProductCategoryUrlSlug, ErrorMessage = "Url Used")]
        [UrlSlugValidator]
        public string UrlSlug { get; set; }

        [Required]
        [RegularExpression("^(?:(?<Item>[a-z0-9\\s]+),)+(?<LastItem>[a-z0-9\\s]+)[\r\n]*$", ErrorMessage = "Comma separated list of lowercase words. Example: dog,cat,puppy,whale shark")]
        public string Keywords { get; set; }
    }
}