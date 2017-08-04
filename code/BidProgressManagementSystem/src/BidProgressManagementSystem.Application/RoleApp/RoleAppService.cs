﻿using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.Application
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _repository;
        public RoleAppService(IRoleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAllList()
        {
            return _repository.GetAllList();
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="startPage">起始页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="rowCount">数据总数</param>
        /// <returns></returns>
        public List<Role> GetAllPageList(int startPage, int pageSize, out int rowCount)
        {
            return _repository.LoadPageList(startPage, pageSize, out rowCount, null, it => it.Id).ToList();
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public bool InsertOrUpdate(Role role)
        {
            var menu = _repository.InsertOrUpdate(role);
            return menu == null ? false : true;
        }

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        public void DeleteBatch(List<Guid> ids)
        {
            _repository.Delete(it => ids.Contains(it.Id));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Role Get(Guid id)
        {
            return _repository.Get(id);
        }

        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllMenuListByRole(Guid roleId)
        {
            return _repository.GetAllMenuListByRole(roleId);
        }

        /// <summary>
        /// 更新角色权限关联关系
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleMenus">角色权限集合</param>
        /// <returns></returns>
        public bool UpdateRoleMenu(Guid roleId, List<RoleMenu> roleMenus)
        {
            return _repository.UpdateRoleMenu(roleId, roleMenus);
        }
    }
}
