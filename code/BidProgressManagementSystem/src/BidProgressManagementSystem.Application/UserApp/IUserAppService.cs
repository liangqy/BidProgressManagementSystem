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


        bool InsertOrUpdate(User user);

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
        /// <param name="id">用于判断是不是超级用户</param>
        /// <returns></returns>
        List<User> GetAll();
        /// <summary>
        /// 分页获取所有用户
        /// </summary>
        /// <param name="startPage">起始页</param>
        /// <param name="pageSize">每页的大小</param>
        /// <param name="rowCount">输出一共多少个</param>
        /// <returns></returns>
        List<User> GetAllPageList(int startPage, int pageSize, out int rowCount);
        
        bool CheckSupervisor(Guid id);


        User GetWithProject(Guid id);
	}
}
