using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Web.CustomValidators;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// TODO comment
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

        #region Product Category

        /// <summary>
        /// Product Category Name
        /// </summary>
        [DisplayName("Product Category Name")]
        [ReadOnly(true)]
        public int ProductCategoryName { get; set; }

        /// <summary>
        /// Product Category Id
        /// </summary>
        [DisplayName("Product Category Description")]
        [ReadOnly(true)]
        public int ProductCategoryDescription { get; set; }

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
        public List<ProductImageViewModel> ProductImages { get; set; }


    }
}