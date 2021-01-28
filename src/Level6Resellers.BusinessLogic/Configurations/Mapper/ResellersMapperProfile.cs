using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.DataTransferObjects.Products;
using Level6Resellers.DataTransferObjects.Purchases;
using Level6Resellers.DataTransferObjects.Users;
using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Products;
using Level6Resellers.Domain.Purchases;
using Level6Resellers.Domain.Users;
using System.Linq;

namespace Level6Resellers.BusinessLogic.Configurations.Mapper
{
    public class ResellersMapperProfile : MapperProfileBase
    {
        public ResellersMapperProfile()
        {
            CreateMapperConfig();
        }

        /// <summary>
        /// Maps entities <---> dtos
        /// </summary>
        internal void CreateMapperConfig()
        {
            //CustomerCompany to CustomerCompanyDto, CustomerCompanyDto to CustomerCompany
            CreateMap<CustomerCompany, CustomerCompanyDto>()
                .ForMember(dto => dto.PurchaseIds, map => map.MapFrom(org => org.Purchases.Select(x => x.Id)))
                .ForMember(dto => dto.UserIds, map => map.MapFrom(org => org.Users.Select(x => x.Id)))
                .ForMember(dto => dto.ProductIds, map => map.MapFrom(org => org.ProductResellerCustomers.Select(x => x.ProductId)))
                .ForMember(dto => dto.ResellerIds, map => map.MapFrom(org => org.ResellerCustomers.Select(x => x.ResellerCompanyId)))
                .ReverseMap();

            //CustomerCompany to CustomerCompanyInputDto, CustomerCompanyInputDto to CustomerCompany
            CreateMap<CustomerCompany, CustomerCompanyInputDto>()
                .ReverseMap();

            //ResellerCompany to ResellerCompanyDto, ResellerCompanyDto to ResellerCompany
            CreateMap<ResellerCompany, ResellerCompanyDto>()
                .ForMember(dto => dto.CustomerIds, map => map.MapFrom(org => org.ResellerCustomers.Select(x => x.CustomerCompanyId)))
                .ForMember(dto => dto.ProductIds, map => map.MapFrom(org => org.ProductResellerCustomers.Select(x => x.ProductId)))
                .ReverseMap();

            //ResellerCompany to ResellerCompanyInputDto, ResellerCompanyInputDto to ResellerCompany
            CreateMap<ResellerCompany, ResellerCompanyInputDto>()
                .ReverseMap();

            // ResellerCustomer to ResellerCustomerDto, ResellerCustomerDto to ResellerCustomer
            CreateMap<ResellerCustomer, ResellerCustomerDto>()
                .ReverseMap();

            // ResellerCustomer to ResellerCustomerInputDto, ResellerCustomerInputDto to ResellerCustomer
            CreateMap<ResellerCustomer, ResellerCustomerInputDto>()
                .ReverseMap();

            //Product to ProductDto, ProductDto to Product
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.CustomerIds, map => map.MapFrom(org => org.ProductResellerCustomers.Select(x => x.CustomerId)))
                .ForMember(dto => dto.ResellerIds, map => map.MapFrom(org => org.ProductResellerCustomers.Select(x => x.ResellerId)))
                .ReverseMap();

            //Product to ProductInputDto, ProductInputDto to Product
            CreateMap<Product, ProductInputDto>()
                .ReverseMap();

            //ProductResellerCustomer to ProductResellerCustomerDto, ProductResellerCustomerDto to ProductResellerCustomer
            CreateMap<ProductResellerCustomer, ProductResellerCustomerDto>()
                .ReverseMap();

            //ProductResellerCustomer to ProductResellerCustomerInputDto, ProductResellerCustomerInputDto to ProductResellerCustomer
            CreateMap<ProductResellerCustomer, ProductResellerCustomerInputDto>()
                .ReverseMap();

            //UserCustomer to UserCustomerDto, UserCustomerDto to UserCustomer
            CreateMap<UserCustomer, UserCustomerDto>()
                .ForMember(dto => dto.PurchaseIds, map => map.MapFrom(org => org.Purchases.Select(x => x.Id)))
                .ReverseMap();

            //UserCustomer to UserCustomerInputDto, UserCustomerInputDto to UserCustomer
            CreateMap<UserCustomer, UserCustomerInputDto>()
                .ReverseMap();

            //Purchase to PurchaseDto, PurchaseDto to Purchase
            CreateMap<Purchase, PurchaseDto>()
                .ReverseMap();


        }
    }
}
