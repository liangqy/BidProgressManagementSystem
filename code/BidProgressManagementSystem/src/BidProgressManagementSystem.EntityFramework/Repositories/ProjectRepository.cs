using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(MyDBContext dbContext) : base(dbContext)
        {
        }

        public List<UserProject> GetAllListByUser(Guid userId)
        {
            return _dbContext.Set<UserProject>().Where(it => it.UserId == userId).ToList();
        }
    }
}
