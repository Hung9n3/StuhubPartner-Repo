using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    class EmployeeInfoDTO : BaseEntityDTO
    {
        public string EmployeeName { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public Address Address { get; set; }
    }
}
