using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    /// <summary>
    /// 用户标关系
    /// </summary>
    public class UserProject
    {
        /// <summary>
        /// 参与者的职责 项目负责人 投标负责人 投保参与人 其他
        /// </summary>
        public int Responsibility { set; get; }
        public Guid UserId { set; get; }
        public User User { set; get; }
        public Guid ProjectId { set; get; }
        public Project Project { set; get; }
    }
    public enum UserResponsibility {
        项目负责人 = 0,
        投标负责人 = 1,
        投保参与人 = 2,
        其他 = 3
    }
}
