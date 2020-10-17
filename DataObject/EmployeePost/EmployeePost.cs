using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject.EmployeePost
{
    public class EmployeePost
    {
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int Attendance { get; set; }
        public int LocationId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string HouseNo { get; set; }
        public string StreetAddress { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
    }
}
