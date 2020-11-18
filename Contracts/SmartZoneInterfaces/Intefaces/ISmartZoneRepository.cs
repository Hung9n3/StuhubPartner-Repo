using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Models.SmartZoneContext;

namespace Contracts.SmartZoneInterfaces.Interfaces
{
    public interface ISmartZoneRepository : IRepositoryBase<SmartZone>
    {
        IQueryable<SmartZone> FindAllIncludesDeleted(Expression<Func<SmartZone, bool>>? predicate);
        Task<SmartZone?> FindByGuidAsync(string guid);
    }
}
