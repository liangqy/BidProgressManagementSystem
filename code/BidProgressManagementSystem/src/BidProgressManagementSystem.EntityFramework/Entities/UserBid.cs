using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    /// <summary>
    /// 用户标关系
    /// </summary>
    public class UserBid : Entity
    {
        public Guid UserId { set; get; }
        public User User { set; get; }
        public Guid BidId { set; get; }
        public Bid Bid { set; get; }
    }
}
