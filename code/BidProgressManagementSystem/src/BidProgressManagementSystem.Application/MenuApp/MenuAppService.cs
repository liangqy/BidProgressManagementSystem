using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BidProgressManagementSystem.Application
{
    public class MenuAppService : IMenuAppService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public MenuAppService(IMenuRepository menuRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public List<Menu> GetAllList()
        {
			return _menuRepository.GetAllList().OrderBy(it=>it.SerialNumber).ToList();
        }

        public List<Menu> GetMenusByParent(Guid parentId, int startPage, int pageSize, out int rowCount)
        {
            return _menuRepository.LoadPageList(startPage, pageSize, out rowCount, it => it.ParentId == parentId, it => it.SerialNumber).ToList();
        }

        public bool InsertOrUpdate(Menu menu)
        {
            var v_menu = _menuRepository.InsertOrUpdate(menu);
            return v_menu == null ? false : true;
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _menuRepository.Delete(it => ids.Contains(it.Id));
        }

        public void Delete(Guid id)
        {
            _menuRepository.Delete(id);
        }

        public Menu Get(Guid id)
        {
            return _menuRepository.Get(id);
        }
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<Menu> GetMenusByUser(Guid userId)
        {
            List<Menu> result = new List<Menu>();
            var allMenus = _menuRepository.GetAllList(it=>it.Type == 0).OrderBy(it => it.SerialNumber);
            if (_userRepository.CheckSupervisor(userId))
                return (List<Menu>)allMenus;          
            var user = _userRepository.GetWithRoles(userId);
            if (user == null)
                return result;
            var userRoles = user.UserRoles;
            List<Guid> menuIds = new List<Guid>();
            foreach (var role in userRoles)
            {
                menuIds = menuIds.Union(_roleRepository.GetAllMenuListByRole(role.RoleId)).ToList();
            }
            allMenus = allMenus.Where(it => menuIds.Contains(it.Id)).OrderBy(it => it.SerialNumber);
            return (List<Menu>)(allMenus);
        }
    }
}
