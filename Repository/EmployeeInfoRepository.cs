using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeInfoRepository : RepositoryBase<EmployeeInfo>, IEmployeeInfoRepository
    {
        public EmployeeInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public override async Task<EmployeeInfo> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var employee = await _dbSet.Where(x => x.Id == id)
                                       .Include(x => x.Location).Include(x => x.Address).FirstAsync();
            return employee;
        }
    }
}
