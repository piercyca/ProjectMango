using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;
using Mango.Core.Web.CustomValidators;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="Product" />
    /// </summary>
    public class ProductFormViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        /// <summary>
        /// Product Category Id
        /// </summary>
        [DisplayName("Product Category")] 
        [Required]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Select list items for product categories dropdown
        /// </summary>
        public IEnumerable<SelectListItem> ProductCategories { get; set; }

        /// <summary>
        /// Product Url Slug
        /// </summary>
        [DisplayName("Url Slug")]
        [Required]
        [UniqueValidator("ProductId", UniqueValidatorType.ProductUrlSlug, ErrorMessage = "Url Slug Used")]
        [UrlSlugValidator]
        public string UrlSlug { get; set; }

        /// <summary>
        /// Product Url Slug, used to compare to UrlSlug when 
        /// saving to determine if a redirect should be created.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string UrlSlugCompare { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [Required]
        [AllowHtml]
        public string Description { get; set; }

        /// <summary>
        /// Product Images
        /// </summary>
        [DisplayName("Product Images")]
        public IEnumerable<ProductImageFormViewModel> ProductImages { get; set; }

        /// <summary>
        /// Product Images string, for saving, populated by JavaScript on the client
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string ProductImagesString { get; set; }

        /// <summary>
        /// Featured Homepage
        /// </summary>
        [DisplayName("Featured (Homepage)")]
        public bool FeaturedHomepage { get; set; }


        public UploadImageViewModel UploadProductImageViewModel { get; set; }

        public ProductFormViewModel()
        {
            UploadProductImageViewModel = new UploadImageViewModel("modalUploadProductImage");
        }
    }
}