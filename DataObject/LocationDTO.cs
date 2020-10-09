using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class LocationDTO
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Menu Menu { get; set; }
    }
}
