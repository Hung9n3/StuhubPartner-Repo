using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SmartZoneContext
{
    public class SmartZone : BaseEntity 
    {
        public string Guid { get; set; } = null!;
        public string SmartZoneName { get; set; } = String.Empty;
        public int Seats { get; set; }
        public int Rooms { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public int? Rating { get; set; }
        public string WifiPass { get; set; } = String.Empty;
        public string FacebookLink { get; set; } = String.Empty;
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsExpired { get; set; }
    }
}
