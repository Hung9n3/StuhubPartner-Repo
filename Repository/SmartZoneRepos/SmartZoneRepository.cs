using Contracts.SmartZoneInterfaces.Interfaces;
using Entities.Models.SmartZoneContext;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.SmartZoneRepos
{
    public class SmartZoneRepository : RepositoryBase<SmartZone>, ISmartZoneRepository
    {
        public SmartZoneRepository(SmartZoneContext szc) : base(szc) {}
        public override IQueryable<SmartZone> FindAll(Expression<Func<SmartZone, bool>>? predicate)
            => _dbSet.Where(sz => !sz.IsDeleted).WhereIf(predicate != null, predicate!);
        public IQueryable<SmartZone> FindAllIncludesDeleted(Expression<Func<SmartZone, bool>> predicate)
            => _dbSet.WhereIf(predicate != null, predicate!);
        public async Task<SmartZone?> FindByGuidAsync(string guid)
            => await FindAll(sz => sz.Guid == guid).FirstOrDefaultAsync();
        public override void Delete(SmartZone entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
    }
}
