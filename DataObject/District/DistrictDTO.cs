using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class DistrictDTO : BaseEntityDTO
    {
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
