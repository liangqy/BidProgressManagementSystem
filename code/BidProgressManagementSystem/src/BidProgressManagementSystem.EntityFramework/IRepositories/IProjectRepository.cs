using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    public interface IProjectRepository:IRepository<Project>
    {
        Project GetWithUsers(Guid id);
    }
}
