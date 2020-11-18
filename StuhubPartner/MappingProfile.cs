using AutoMapper;
using DataObject;
using DataObject.Identity;
using DataObject.SmartZone.SmartZone;
using Entities;
using Entities.Models;
using Entities.Models.IdentityContext;
using Entities.Models.SmartZoneContext;
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
            CreateMap<UserDTO, User>().ForMember(d => d.Guid, o => o.Ignore()).ForMember(d => d.SmartZoneId, o => o.Ignore());
            CreateMap<SmartZoneDTO, SmartZone>().ForMember(d => d.Id, o => o.Ignore()).ForMember(d => d.Guid, o => o.Ignore());
        }
    }
}
