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

        public List<UserProject> GetAllPageListByUser(Guid userId, int startPage, int pageSize, out int rowCount)
        {
            var result = from p in _dbContext.Set<UserProject>() select p;
            result = result.Where(it => it.UserId == userId);
            result = result.OrderBy(it => it.ProjectId);
            rowCount = result.Count();
            return result.Skip((startPage - 1) * pageSize).Take(pageSize).ToList();
        }

        //public List<UserProject> GetAllPageListByUser(Guid userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
