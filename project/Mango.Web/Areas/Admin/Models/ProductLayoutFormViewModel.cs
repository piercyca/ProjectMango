using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductLayoutFormViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        /// <summary>
        /// Configuration
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string Configuration { get; set; }

        /// <summary>
        /// Canvas Image
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string CanvasImage { get; set; }
    }
}