using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    public class Bid : Entity
    {
        /// <summary>
        /// 标的识别号
        /// </summary>
        public string BidCode { set; get; }
        /// <summary>
        /// 标名
        /// </summary>
        public string BidName { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 标的状态
        /// </summary>
        public int Status { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 标状态集合
        /// </summary>
        public virtual ICollection<BidBidStatus> BidBidStatuss { set; get; }
    }
}