using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    /// <summary>
    /// 标的状态
    /// </summary>
    public class BidStatus:Entity
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public Guid CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
