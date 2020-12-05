using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SmartZoneContext
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public double? Kalories { get; set; }
        public DateTime TimeToMake { get; set; }
        public int Price { get; set; }
        public int? Rating { get; set; }
        public virtual ICollection<MenuItemImage> Images { get; set; } = new HashSet<MenuItemImage>();
    }
}
