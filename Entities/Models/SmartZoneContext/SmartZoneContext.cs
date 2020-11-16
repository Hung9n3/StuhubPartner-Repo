using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.SmartZoneContext
{
    public partial class SmartZoneContext : DbContext
    {
        public SmartZoneContext() : base(){}

        public SmartZoneContext(DbContextOptions<SmartZoneContext> options) : base(options) { }

    }
}
