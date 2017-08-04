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
        public UserAppService(IUserRepository userRepository, IProjectRepository projectRepository)
        {
            _repository = userRepository;
            _projectRepository = projectRepository;
        }

        public User CheckUser(string userName, string password)
        {
            return _repository.CheckUser(userName, password);
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
            return _repository.Get(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAllList();
        }

        public User GetProjects(Guid id)
        {
            //if (_repository.CheckSupervisor(id))
            //    return _projectRepository.GetAllList();
            return _repository.GetWithProjects(id);
        }

        public User InsertOrUpdate(User user)
        {
            if (Get(user.Id) != null)
                _repository.Delete(user.Id);
            return _repository.InsertOrUpdate(user);
        }
    }
}
