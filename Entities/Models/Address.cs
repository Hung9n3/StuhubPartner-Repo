﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Address : BaseEntity
    {
        public string StreetAddress { get; set; }
        public string HouseNo { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; }
        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
