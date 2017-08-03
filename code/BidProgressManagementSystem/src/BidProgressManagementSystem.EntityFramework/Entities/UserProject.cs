using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    /// <summary>
    /// 用户标关系
    /// </summary>
    public class UserProject
    {
        public Guid UserId { set; get; }
        public User User { set; get; }
        public Guid ProjectId { set; get; }
        public Project Project { set; get; }
    }
}
