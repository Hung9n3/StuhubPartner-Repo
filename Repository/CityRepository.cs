using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public override async Task<City> FindByIdAsync(int id)
        {
            var item = await repositoryContext.Cities.Where(x => x.CityID == id).Include(x => x.Districts)
                                               .AsNoTracking().FirstAsync();
            return item;
        }
    }
}
