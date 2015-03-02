using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Admin.Models;
using Mango.Admin.ViewModels;
using Mango.Core.Entity;
using Mango.Core.Repository;
using Mango.Core.Service;

namespace Mango.Admin.Controllers
{ 
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
    }
}