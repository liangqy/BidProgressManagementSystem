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
        Project IProjectRepository.GetWithUsers(Guid id)
        {
            var project = _dbContext.Set<Project>().FirstOrDefault(it => it.Id == id);
            if (project != null)
            {
                project.UserProjects = _dbContext.Set<UserProject>().Where(it => it.UserId == id).ToList();
            }
            return project;
        }
    }
}
