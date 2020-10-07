using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
   public class DistrictAddDTO
    {
        public string DistrictName { get; set; }
        public int cityID { get; set; }
        public City City { get; set; }
    }
}
