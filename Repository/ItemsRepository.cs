using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ItemsRepository : RepositoryBase<Item> , IItemsRepository
    {
        public ItemsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
