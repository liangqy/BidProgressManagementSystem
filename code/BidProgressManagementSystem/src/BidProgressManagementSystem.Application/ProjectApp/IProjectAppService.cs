using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.Application
{
    public interface IProjectAppService
    {
        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        List<Project> GetAllList();
        /// <summary>
        /// 获取特定项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project Get(Guid id);
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        List<Project> GetAllPageList(int startPage, int pageSize, out int rowCount);

        

        /// <summary>
        /// 新增或删除
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool InsertOrUpdate(Project project);

        /// <summary>
        /// 根据Id批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteBatch(List<Guid> ids);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>

        void Delete(Guid id);


        /// <summary>
        /// 获取项目相关的用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project GetWithUser(Guid id);
    }
}
