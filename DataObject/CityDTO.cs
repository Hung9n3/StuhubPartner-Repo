﻿using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataObject
{
    public class CityDTO
    {
        public string CityName { get; set; }
        public ICollection<District> Districts { get; set; }
        
    }
}
