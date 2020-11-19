using Entities.Models.IdentityContext;
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
        public string SmartZoneAddress1 { get; set; } = String.Empty;
        public string SmartZoneAddress2 { get; set; } = String.Empty;
        public bool IsDeleted { get; set; }
        public bool IsExpired { get; set; }

        //public User SmartZoneOwner { get; set; }
    }
}
