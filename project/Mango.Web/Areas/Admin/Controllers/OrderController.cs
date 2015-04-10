using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web.Extensions;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class OrderController : Controller
    {
        private readonly IOrderService _orderService;
	    private readonly IOrderLineItemService _orderLineItemService;

        public OrderController() { }

		public OrderController(IOrderService orderService, IOrderLineItemService orderLineItemService)
        {
            _orderService = orderService;
			_orderLineItemService = orderLineItemService;
        }

        /// <summary>
        /// GET: /orders/
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return RedirectToActionPermanent(MVC.Admin.Order.List());
        }

        /// <summary>
        /// GET: /orders/list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult List() //TODO (later) paginate .... string sortBy = "Date", int page = 0
        {
            var orders = _orderService.GetOrders();
            
            return View(orders);
        }

		/// <summary>
		/// GET: /orders/details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Details(int orderId)
        {
            var orderLineItems = _orderLineItemService.GetOrderLineItemsByOrder(orderId);

			return View(orderLineItems);
        }

    }
}