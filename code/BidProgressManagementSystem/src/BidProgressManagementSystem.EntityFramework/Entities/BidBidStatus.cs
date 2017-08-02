using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    /// <summary>
    /// 标的状态日志
    /// 用于记录标的状态的更改历史信息
    /// </summary>
    public class BidBidStatus
    {
        /// <summary>
        /// 修改状态的用户ID
        /// </summary>
        public Guid UserId { set; get; }
        public User User { set; get; }
        /// <summary>
        /// 被修改的标的编号
        /// </summary>
        public Guid BidId { set; get; }
        public Bid Bid { set; get; }
        /// <summary>
        /// 原始状态
        /// </summary>
        public Guid LastStatusId { set; get; }
        public BidStatus LastStatus{ set; get; }
        /// <summary>
        /// 修改后的状态
        /// </summary>
        public Guid StatusNowId { set; get; }
        public BidStatus StatusNow { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? StatusChangeTime { set; get; }
        /// <summary>
        /// 修改说明
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

    }
}
