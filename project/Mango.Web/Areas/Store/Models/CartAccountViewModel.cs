using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Web.Models;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CartAccountViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        /// <summary>
        /// 'Register', 'Login', or ''
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string LoginMethod { get; set; }
    }
}