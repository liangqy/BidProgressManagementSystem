using BidProgressManagementSystem.EntityFramework.Entities;
using BidProgressManagementSystem.EntityFramework.IRepositories;
using System;
using System.Linq;

namespace BidProgressManagementSystem.EntityFramework.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
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
        //static void main(string[] args)
        //{
        //    var context = new MyDBContext();
        //    var userrepository = new UserRepository(context);
        //    Console.WriteLine(userrepository.CheckUser("admin", "123456"));
        //}
    }  
}
