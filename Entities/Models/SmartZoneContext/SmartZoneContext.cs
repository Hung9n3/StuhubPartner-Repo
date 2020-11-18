using Microsoft.EntityFrameworkCore;

namespace Entities.Models.SmartZoneContext
{
    public partial class SmartZoneContext : DbContext
    {
        //public SmartZoneContext() : base(){}

        public SmartZoneContext(DbContextOptions<SmartZoneContext> options) : base(options) { }

        public virtual DbSet<SmartZone> SmartZones { get; set; } = null;

    }
}
