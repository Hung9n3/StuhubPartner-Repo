using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
   public class City 
    {
        [Key]
        public int CityID { get; set; }
        [Required]
        public string CityName { get; set; }
        public ICollection<District> Districts { get; set; } 
    }
}
