using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class EmployeeInfo : BaseEntity
    {
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int Attendance { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; } 
    }
}
