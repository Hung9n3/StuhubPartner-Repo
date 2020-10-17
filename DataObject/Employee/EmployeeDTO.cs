using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataObject
{
    public class EmployeeDTO : BaseEntityDTO
    {
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int Attendance { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
    }
}
