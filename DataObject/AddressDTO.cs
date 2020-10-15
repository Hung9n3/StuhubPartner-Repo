using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class AddressDTO : BaseEntity
    {
        public string StreetAddress { get; set; }
        public string HouseNo { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
