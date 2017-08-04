using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BidProgressManagementSystem.Application
{
    
    public class ProjectAppService:IProjectAppService
    {
        private readonly ProjectRepository _repository;

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _repository.Delete(it=>ids.Contains(it.Id));
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
            return _repository.LoadPageList(startPage, pageSize, out rowCount, null, it => it.Id).ToList();
        }

        public Project GetWithUser(Guid id)
        {
            return _repository.GetWithUsers(id);
        }

        public bool InsertOrUpdate(Project project)
        {
            var project_v = _repository.InsertOrUpdate(project);
            return project_v == null ? false : true; 
        }
    }
}
