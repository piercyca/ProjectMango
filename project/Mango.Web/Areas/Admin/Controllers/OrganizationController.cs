using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController() { }

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// GET: /organization/
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return RedirectToActionPermanent(MVC.Admin.Organization.List());
        }

        /// <summary>
        /// GET: /organization/list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult List()
        {
            var productViewModel = new OrganizationListViewModel
            {
                OrganizationList = Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationListItemViewModel>>(_organizationService.GetOrganizations())
            };
            return View(productViewModel);
        }

        /// <summary>
        /// GET: /organizations/edit/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var organization = _organizationService.GetOrganization(id);
            var vm = Mapper.Map<Organization, OrganizationFormViewModel>(organization);
            return View(vm);
        }

        /// <summary>
        /// POST: /organizations/edit/{id}
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Edit(OrganizationFormViewModel vm)
        {
            var organization = Mapper.Map<OrganizationFormViewModel, Organization>(vm);
            if (ModelState.IsValid)
            {
                _organizationService.EditOrganization(organization);
                return RedirectToAction(MVC.Admin.Organization.List());
            }
            return View(vm);
        }

        /// <summary>
        /// GET: /organizations/create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Create()
        {
            var vm = Mapper.Map<Organization, OrganizationFormViewModel>(new Organization());
            return View(vm);
        }

        /// <summary>
        /// POST: /organizations/create
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Create(OrganizationFormViewModel vm)
        {
            var organization = Mapper.Map<OrganizationFormViewModel, Organization>(vm);
            if (ModelState.IsValid)
            {
                _organizationService.CreateOrganization(organization);
                return RedirectToAction(MVC.Admin.Organization.List());
            }
            return View(vm);
        }
    }
}