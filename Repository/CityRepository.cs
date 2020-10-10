using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public override async Task<City> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _context.Cities.Where(x => x.Id == id).Include(x => x.Districts)
                                               .AsNoTracking().FirstAsync();
            return item;
        }
    }
}
