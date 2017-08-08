using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidProgressManagementSystem.EntityFramework;

namespace BidProgressManagementSystem.Application
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserAppService : IUserAppService
    {
        //用户管理仓储接口
        private readonly IUserRepository _repository;
        private readonly IProjectRepository _projectRepository;
        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public UserAppService(IUserRepository userRepository,IProjectRepository projectRepository)
        {
            _repository = userRepository;
            _projectRepository = projectRepository;
        }

        public bool CheckSupervisor(Guid id)
        {
            return _repository.CheckSupervisor(id);
        }

        public User CheckUser(string userName, string passWord)
        {
            return _repository.CheckUser(userName, passWord);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _repository.Delete(it => ids.Contains(it.Id));
        }

        public User Get(Guid id)
        {
			return _repository.GetWithRoles(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAllList();
        }

        public List<User> GetAllPageList(int startPage, int pageSize, out int rowCount)
        {
            return _repository.LoadPageList(startPage, pageSize, out rowCount, null, it => it.Id).ToList();
        }

        public User GetWithProject(Guid id)
        {
            var user = _repository.Get(id);
            user.UserProjects = _projectRepository.GetAllListByUser(id);
            foreach (UserProject userProject in user.UserProjects)
            {
                userProject.Project = _projectRepository.Get(userProject.ProjectId);
            }
            return user;
        }

        public bool InsertOrUpdate(User user)
        {
			if (Get(user.Id) != null)
				_repository.Delete(user.Id);
			var temp = _repository.InsertOrUpdate(user);
            return temp == null ? false : true;
        }
    }
}
