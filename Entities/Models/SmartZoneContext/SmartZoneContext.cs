using Microsoft.EntityFrameworkCore;

namespace Entities.Models.SmartZoneContext
{
    public partial class SmartZoneContext : DbContext
    {
        public SmartZoneContext() : base(){}

        public SmartZoneContext(DbContextOptions<SmartZoneContext> options) : base(options) { }

    }
}
