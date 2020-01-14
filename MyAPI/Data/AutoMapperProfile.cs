using AutoMapper;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Hotel, HotelModel>();
            CreateMap<Location, LocationModel>();
            CreateMap<HotelModel, Hotel>();
            CreateMap<LocationModel, Location>();
            //.ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name));

            //        Mapper.CreateMap<DataModels.Customer, CustomerDetailsViewModel>()
            //.ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));
            //        /* etc, for other address properties */
        }
    }
}
