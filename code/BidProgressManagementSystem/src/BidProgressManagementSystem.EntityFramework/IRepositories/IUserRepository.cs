using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.EntityFramework
{
    /// <summary>
    /// 用户管理仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        User CheckUser(string userName, string password);
        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetWithRoles(Guid id);
        /// <summary>
        /// 获取用户相关的项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetWithProjects(Guid id);
        /// <summary>
        /// 分页查询用户的项目
        /// </summary>
        /// <returns></returns>
        List<Project> GetProjectsWithPage(Guid id);
        /// <summary>
        /// 检查是否超管
        /// </summary>
        Boolean CheckSupervisor(Guid id);
    }
}
