using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    public interface IProjectRepository:IRepository<Project>
    {
        //List<UserProject> GetAllUserListByProject(Guid id);
        List<UserProject> GetAllListByUser(Guid userId);
    }
}
