using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            #region Area_Admin

            Mapper.CreateMap<Address, Areas.Admin.Models.AddressFormViewModel>();
            Mapper.CreateMap<Customer, Areas.Admin.Models.CustomerFormViewModel>();
            Mapper.CreateMap<Organization, Areas.Admin.Models.OrganizationFormViewModel>();
            Mapper.CreateMap<Organization, Areas.Admin.Models.OrganizationListItemViewModel>();
            Mapper.CreateMap<OrganizationImage, Areas.Admin.Models.OrganizationImageFormViewModel>();
            Mapper.CreateMap<Product, Areas.Admin.Models.ProductFormViewModel>().ForMember(dest => dest.UrlSlugCompare, opt => opt.MapFrom(src => src.UrlSlug));
            Mapper.CreateMap<Product, Areas.Admin.Models.ProductLayoutFormViewModel>();
            Mapper.CreateMap<Product, Areas.Admin.Models.ProductListItemViewModel>();
            Mapper.CreateMap<ProductCategory, Areas.Admin.Models.ProductCategoryFormViewModel>();
            Mapper.CreateMap<ProductCategory, Areas.Admin.Models.ProductCategoryListItemViewModel>();
            Mapper.CreateMap<ProductImage, Areas.Admin.Models.ProductImageFormViewModel>();

            #endregion

            #region Area_Store

            Mapper.CreateMap<Address, Areas.Store.Models.AddressViewModel>();
            Mapper.CreateMap<Customer, Areas.Store.Models.CustomerViewModel>();
            Mapper.CreateMap<Order, Areas.Store.Models.OrderViewModel>();
            Mapper.CreateMap<Product, Areas.Store.Models.ProductDetailViewModel>();
            Mapper.CreateMap<ProductCategory, Areas.Store.Models.ProductCategoryDetailViewModel>();
            Mapper.CreateMap<ProductImage, Areas.Store.Models.ProductImageViewModel>();

            #endregion

            //Mapper.CreateMap<X, XViewModel>()
            //    .ForMember(x => x.Property1, opt => opt.MapFrom(source => source.PropertyXYZ));
            //Mapper.CreateMap<Goal, GoalListViewModel>().ForMember(x => x.SupportsCount, opt => opt.MapFrom(source => source.Supports.Count))
            //                                          .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.User.UserName))
            //                                          .ForMember(x => x.StartDate, opt => opt.MapFrom(source => source.StartDate.ToString("dd MMM yyyy")))
            //                                          .ForMember(x => x.EndDate, opt => opt.MapFrom(source => source.EndDate.ToString("dd MMM yyyy")));
            //Mapper.CreateMap<Group, GroupsItemViewModel>().ForMember(x => x.CreatedDate, opt => opt.MapFrom(source => source.CreatedDate.ToString("dd MMM yyyy")));

            //Mapper.CreateMap<IPagedList<Group>, IPagedList<GroupsItemViewModel>>().ConvertUsing<PagedListConverter<Group, GroupsItemViewModel>>();


        }
    }
}