using DataObject.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataObject.SmartZone.SmartZone
{
    public class SmartZoneDTO : BaseEntityDTO
    {
        [FromRoute]
        public string Guid { get; set; }
        [Required]
        public string SmartZoneName { get; set; } = String.Empty;
        [Required]
        public string SmartZoneAddress1 { get; set; } = String.Empty;
        public string SmartZoneAddress2 { get; set; } = String.Empty;
        public bool IsDeleted { get; set; }
        public bool IsExpired { get; set; }

        public UserDTO SmartZoneOwner { get; set; }
    }
}
