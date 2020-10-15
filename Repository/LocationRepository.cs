using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public override async Task<Location> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var location = await _dbSet.Where(x => x.Id == id).Include(x => x.Address).AsNoTracking().FirstAsync();
            return location;
        }
    }
}
