using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;
using Mango.Web.Areas.Admin.Models;

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
            Mapper.CreateMap<Address, AddressFormViewModel>();

            Mapper.CreateMap<Organization, OrganizationFormViewModel>();
            Mapper.CreateMap<Organization, OrganizationListItemViewModel>();
            Mapper.CreateMap<Product, ProductFormViewModel>().ForMember(dest => dest.UrlSlugCompare, opt => opt.MapFrom(src => src.UrlSlug));
            Mapper.CreateMap<Product, ProductLayoutFormViewModel>();
            Mapper.CreateMap<Product, ProductListItemViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryFormViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryListItemViewModel>();
            Mapper.CreateMap<ProductImage, ProductImageFormViewModel>();

			Mapper.CreateMap<Customer, CustomerFormViewModel>();

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