using BidProgressManagementSystem.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.IRepositories
{
    public interface IProjectRepository:IRepository<Project>
    {
        Project GetWithUsers(Guid id);
    }
}
