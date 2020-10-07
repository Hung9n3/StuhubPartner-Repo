using AutoMapper;
using DataObject;
using Entities;
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
            CreateMap<CityAddDTO, City>().ForMember(x => x.CityID, opt => opt.Ignore());
            CreateMap<City, CityShow>();
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>().ForMember(x => x.CityID, opt => opt.Ignore());
            CreateMap<District, DistrictDTO>();
            CreateMap<DistrictDTO, District>().ForMember(x => x.DistrictID, opt => opt.Ignore());
            CreateMap<LocationDTO, Location>().ForMember(x => x.LocationID, opt => opt.Ignore());
        }
    }
}
