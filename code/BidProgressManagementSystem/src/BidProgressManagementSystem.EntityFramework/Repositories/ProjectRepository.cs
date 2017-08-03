using BidProgressManagementSystem.EntityFramework.Entities;
using BidProgressManagementSystem.EntityFramework.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
