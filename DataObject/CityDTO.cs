using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataObject
{
    public class CityDTO : BaseEntityDTO
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public ICollection<District> Districts { get; set; }
        
    }
}
