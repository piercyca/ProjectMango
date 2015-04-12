using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;
using Mango.Core.Web.CustomValidators;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// View Model for <seealso cref="Product"/> detail
    /// </summary>
    public class ProductDetailViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [ReadOnly(true)]
        public int ProductId { get; set; }

        /// <summary>
        /// Product Url Slug
        /// </summary>
        [DisplayName("Url Slug")]
        [ReadOnly(true)]
        public string UrlSlug { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")]
        [ReadOnly(true)]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DisplayName("Price")]
        [ReadOnly(true)]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        [ReadOnly(true)]
        public string Description { get; set; }

        #region Product Category

        /// <summary>
        /// Product Category Name
        /// </summary>
        [DisplayName("Product Category Name")]
        [ReadOnly(true)]
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// Product Category Id
        /// </summary>
        [DisplayName("Product Category Description")]
        [ReadOnly(true)]
        public string ProductCategoryDescription { get; set; }

        [Required]
        [DisplayName("Product Category Url Slug")]

        public string ProductCategoryUrlSlug { get; set; }

        [Required]
        [DisplayName("Product Category Keywords")]
        [ReadOnly(true)]
        public string ProductCategoryKeywords { get; set; }

        #endregion

        /// <summary>
        /// Product Images
        /// </summary>
        [DisplayName("Product Images")]
        [ReadOnly(true)]
        public IEnumerable<ProductImageViewModel> ProductImages { get; set; }

        /// <summary>
        /// Canvas Image
        /// </summary>
        [DisplayName("Canvas Image")]
        [ReadOnly(false)]
        public string CanvasImage { get; set; }

        /// <summary>
        /// Canvas Details
        /// </summary>
        [DisplayName("Canvas Configuration")]
        [ReadOnly(false)]
        public string Configuration { get; set; }

        /// <summary>
        /// Featured Homepage
        /// </summary>
        [DisplayName("Featured (Homepage)")]
        [ReadOnly(true)]
        public bool FeaturedHomepage { get; set; }

    }
}