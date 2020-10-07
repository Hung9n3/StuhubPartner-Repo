using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string StreetAddress { get; set; }
        public string HouseNo { get; set; }
        public City City { get; set; }
        public District District { get; set; }
    }
}
