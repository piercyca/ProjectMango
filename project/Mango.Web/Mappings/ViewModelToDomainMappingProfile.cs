using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;


namespace Mango.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            #region Area_Admin

            Mapper.CreateMap<Areas.Admin.Models.AddressFormViewModel, Address>();
            Mapper.CreateMap<Areas.Admin.Models.CustomerFormViewModel, Customer>();
            Mapper.CreateMap<Areas.Admin.Models.OrganizationFormViewModel, Organization>();
            Mapper.CreateMap<Areas.Admin.Models.OrganizationListItemViewModel, Organization>();
            Mapper.CreateMap<Areas.Admin.Models.ProductFormViewModel, Product>();
            Mapper.CreateMap<Areas.Admin.Models.ProductLayoutFormViewModel, Product>();
            Mapper.CreateMap<Areas.Admin.Models.ProductCategoryFormViewModel, ProductCategory>();
            Mapper.CreateMap<Areas.Admin.Models.ProductImageFormViewModel, ProductImage>();

            #endregion

            #region Area_Store

            Mapper.CreateMap<Areas.Store.Models.AddressViewModel, Address>();
            Mapper.CreateMap<Areas.Store.Models.CustomerViewModel, Customer>();
            Mapper.CreateMap<Areas.Store.Models.OrderViewModel, Order>();
            Mapper.CreateMap<Areas.Store.Models.ProductDetailViewModel, Product>();
            Mapper.CreateMap<Areas.Store.Models.ProductImageViewModel, ProductImage>();

            #endregion

            //Mapper.CreateMap<CommentFormModel, Comment>();
            //Mapper.CreateMap<GroupFormModel, Group>();
            //Mapper.CreateMap<FocusFormModel, Focus>();
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}