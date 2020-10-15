using AutoMapper;
using DataObject;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuhubPartner
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<District, DistrictDTO>();
            CreateMap<DistrictDTO, District>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<LocationDTO, Location>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AddressDTO, Address>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<LocationDTO, Address>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
