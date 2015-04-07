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
        private readonly IOrganizationImageService _organizationImageService;

        public OrganizationController() { }

        public OrganizationController(IOrganizationService organizationService, IOrganizationImageService organizationImageService)
        {
            _organizationService = organizationService;
            _organizationImageService = organizationImageService;
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
        /// GET: /organizations/create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Create()
        {
            var viewModel = Mapper.Map<Organization, OrganizationFormViewModel>(new Organization());
            return View(viewModel);
        }

        /// <summary>
        /// POST: /organizations/create
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Create(OrganizationFormViewModel viewModel)
        {
            var organization = Mapper.Map<OrganizationFormViewModel, Organization>(viewModel);
            if (ModelState.IsValid)
            {
                _organizationService.CreateOrganization(organization);
                _organizationImageService.InsertOrganizationImages(organization.OrganizationId, viewModel.OrganizationImagesString);
                return RedirectToAction(MVC.Admin.Organization.List());
            }
            return View(viewModel);
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
            var viewModel = Mapper.Map<Organization, OrganizationFormViewModel>(organization);

            var organizationImages = _organizationImageService.GetOrganizationImages(id);
            viewModel.OrganizationImages = Mapper.Map<IEnumerable<OrganizationImage>, IEnumerable<OrganizationImageFormViewModel>>(organizationImages);


            return View(viewModel);
        }

        /// <summary>
        /// POST: /organizations/edit/{id}
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Edit(OrganizationFormViewModel viewModel)
        {
            var organization = Mapper.Map<OrganizationFormViewModel, Organization>(viewModel);
            if (ModelState.IsValid)
            {
                _organizationService.EditOrganization(organization);
                _organizationImageService.InsertOrganizationImages(organization.OrganizationId, viewModel.OrganizationImagesString);
                return RedirectToAction(MVC.Admin.Organization.List());
            }
            return View(viewModel);
        }

        
    }
}