using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Web.Models;

namespace Mango.Web.Areas.Store.Models
{
    public class CartAccountViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
    }
}