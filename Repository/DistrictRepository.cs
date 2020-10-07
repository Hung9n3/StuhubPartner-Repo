﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public override async Task<District> FindByIdAsync(int id)
        {
            var item = await repositoryContext.Districts.Where(x => x.DistrictID == id)
                                                        .AsNoTracking().FirstAsync();
            return item;
        }
    }
}
