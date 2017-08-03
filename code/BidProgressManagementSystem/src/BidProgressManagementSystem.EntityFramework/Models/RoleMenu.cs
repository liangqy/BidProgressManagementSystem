using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.EntityFramework
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    public class RoleMenu
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
