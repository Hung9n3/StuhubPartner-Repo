using Entities;
using Entities.Models;
using System.Collections.Generic;

namespace DataObject
{
    public class LocationDTO : BaseEntityDTO
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool LocationType { get; set; }
        public string LocationLogo { get; set; }
        public ICollection<LocationImage> LocationImages { get; set; }
        public string HouseNo { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string StreetName {get;set;}
        public Address Address { get; set; }
        public Menu Menu { get; set; }
    }
}
