﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        [Required]
        public string DistrictName { get; set; }
        [ForeignKey("CityID")]
        public int CityID {get;set;}
        public City City { get; set; }
    }
}
