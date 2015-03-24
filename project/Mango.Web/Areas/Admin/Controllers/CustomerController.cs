using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController() { }

		public CustomerController(ICustomerService customerService)
        {
			_customerService = customerService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
			var customers = _customerService.GetCustomers();
			return View(customers);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
			var customer = _customerService.GetCustomer(id);
			var vm = Mapper.Map<Customer, CustomerFormViewModel>(customer);
            return View(vm);
        }

        [HttpPost]
		public virtual ActionResult Edit(CustomerFormViewModel vm)
        {
			var customer = Mapper.Map<CustomerFormViewModel, Customer>(vm);
            if (ModelState.IsValid)
            {
				_customerService.EditCustomer(customer);
				return RedirectToAction(MVC.Admin.Customer.Index());
            }
            return View(vm);
        }

		[HttpGet]
		public virtual ActionResult Create()
		{
			var vm = Mapper.Map<Customer, CustomerFormViewModel>(new Customer());
			return View(vm);
		}

		[HttpPost]
		public virtual ActionResult Create(CustomerFormViewModel vm)
		{
			var customer = Mapper.Map<CustomerFormViewModel, Customer>(vm);
			if (ModelState.IsValid)
			{
				_customerService.CreateCustomer(customer);
				return RedirectToAction(MVC.Admin.Customer.Index());
			}
			return View(vm);
		}
    }
}