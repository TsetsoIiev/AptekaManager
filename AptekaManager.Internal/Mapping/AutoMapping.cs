using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Models;
using AutoMapper;

namespace AptekaManager.Internal.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<MeasurementUnit, MeasurementUnitDto>();
            CreateMap<MeasurementUnitDto, MeasurementUnit>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Pharmacy, PharmacyDto>();
            CreateMap<PharmacyDto, Pharmacy>();
        }
    }
}