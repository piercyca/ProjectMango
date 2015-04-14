using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Mango.Core.Web.Checkout;
using Mango.Web.Areas.Store.Models;

namespace Mango.Web.Areas.Store.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UtilityController : ApiController
    {
        public AddToCartModel AddToCart([FromBody]AddToCartModel cartItem)
        {
            return cartItem;
        }
    }
}
