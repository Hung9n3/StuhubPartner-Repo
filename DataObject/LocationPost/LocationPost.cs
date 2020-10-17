using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject.LocationPost
{
    public class LocationPost : BaseEntityDTO
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool LocationType { get; set; }
        public string LocationLogo { get; set; }
        public ICollection<LocationImage> LocationImages { get; set; }
        public ICollection<EmployeeInfo> employeeInfos { get; set; }
        public string HouseNo { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string StreetAddress { get; set; }
        public Address Address { get; set; }
        public Menu Menu { get; set; }
    }
}
