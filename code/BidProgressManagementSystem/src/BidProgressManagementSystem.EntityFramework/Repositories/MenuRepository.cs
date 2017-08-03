using System;
using System.Collections.Generic;
using System.Text;
using BidProgressManagementSystem.EntityFramework.IRepositories;
using BidProgressManagementSystem.EntityFramework.Entities;

namespace BidProgressManagementSystem.EntityFramework.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
