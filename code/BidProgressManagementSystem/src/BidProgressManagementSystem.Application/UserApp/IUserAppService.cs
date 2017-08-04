using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.Application
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);


        User InsertOrUpdate(User user);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        void DeleteBatch(List<Guid> ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(Guid id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        User Get(Guid id);
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<User> GetAll();
        /// <summary>
        /// 获取特定用户的所有项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetProjects(Guid id);
        /// <summary>
        /// 分页查询用户的项目
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageStart"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        User GetProjectsWithPage(Guid id, int pageStart, int pageSize);

        bool CheckSupervisor(Guid id);

    }
}
