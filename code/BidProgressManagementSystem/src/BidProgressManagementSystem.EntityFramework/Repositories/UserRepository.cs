﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BidProgressManagementSystem.EntityFramework
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
        public User CheckUser(string userName, string password)
        {
            return _dbContext.Set<User>().FirstOrDefault(it => it.UserName == userName && it.Password == password);
        }

        public User GetWithRoles(Guid id)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(it => it.Id == id);
            if (user != null)
            {
                user.UserRoles = _dbContext.Set<UserRole>().Where(it => it.UserId == id).ToList();
            }
            return user;
        }

        public User GetWithProjects(Guid id)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(it => it.Id == id);
            if (user != null)
            {
                user.UserProjects = _dbContext.Set<UserProject>().Where(it => it.UserId == id).ToList();
            }
            return user;
        }
        public bool CheckSupervisor(Guid id) {
            var user = _dbContext.Set<User>().FirstOrDefault(it => it.Id == id);
            if (user == null)
                return false;
            return user.IsSupervisor;
        }
        public List<UserProject> GetAllListByProject(Guid projectId)
        {
            return _dbContext.Set<UserProject>().Where(it => it.ProjectId == projectId).ToList();
        }


        //public List<UserProject> GetAllProjectListByUser(Guid userId)
        //{
        //    return _dbContext.Set<UserProject>().Where(it => it.UserId == userId).ToList();
        //}
    }  
}
