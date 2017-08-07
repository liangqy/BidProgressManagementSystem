using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BidProgressManagementSystem.Application
{

    public class ProjectAppService : IProjectAppService
    {
        private readonly IProjectRepository _repository;
        private readonly IUserRepository _userRepository;
        public ProjectAppService(IProjectRepository projectRepository,IUserRepository userRepository)
        {
            _repository = projectRepository;
            _userRepository = userRepository;
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _repository.Delete(it => ids.Contains(it.Id));
        }

        public Project Get(Guid id)
        {
            return _repository.Get(id);
        }

        public List<Project> GetAllList()
        {
            return _repository.GetAllList();
        }

        public List<Project> GetAllPageList(int startPage, int pageSize, out int rowCount)
        {
            return _repository.LoadPageList(startPage, pageSize, out rowCount, null, it => it.Code).ToList();
        }

        public List<Project> GetAllPageListByUser(Guid userId, int startPage, int pageSize, out int rowCount)
        {
            var userProjects = _repository.GetAllPageListByUser(userId, startPage, pageSize,out rowCount);
            List<Project> projects = new List<Project>();
            foreach (UserProject userProject in userProjects)
            {
                Project project = _repository.Get(userProject.ProjectId);
                projects.Add(project);
            }
            return projects;
        }

        public Project GetWithUser(Guid projectId)
        {
            var project = _repository.Get(projectId);
            project.UserProjects = _userRepository.GetAllListByProject(projectId);
            foreach (UserProject userProject in project.UserProjects)
            {
                userProject.User = _userRepository.Get(userProject.UserId);
            }
            return project;
        }

        public bool InsertOrUpdate(Project project)
        {
            var temp = _repository.InsertOrUpdate(project);
            return temp == null ? false : true;
        }



    }
}
