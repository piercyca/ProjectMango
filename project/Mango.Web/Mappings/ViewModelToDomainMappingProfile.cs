using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Web.ViewModels;
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
            Mapper.CreateMap<AddressFormViewModel, Address>();
            Mapper.CreateMap<ProductFormViewModel, Product>();
            Mapper.CreateMap<ProductCategoryViewModel, ProductCategory>();

			Mapper.CreateMap<CustomerFormViewModel, Customer>();

            //Mapper.CreateMap<CommentFormModel, Comment>();
            //Mapper.CreateMap<GroupFormModel, Group>();
            //Mapper.CreateMap<FocusFormModel, Focus>();
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}