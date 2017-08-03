using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework.Entities
{
    public class Project : Entity
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 建设单位
        /// </summary>
        public string DevelopmentOrganization { set; get; }
        /// <summary>
        /// 招标代理公司
        /// </summary>
        public string AgentOrganization { set; get; }

        /// <summary>
        /// 投标类型（设计、工程总承包、物资、科研、其他）
        /// </summary>
        public string BidType { set; get; }
        /// <summary>
        /// 投标时间
        /// </summary>
        public DateTime? BidTime { set; get; }
        ///// <summary>
        ///// 项目负责人
        ///// </summary>
        //public string PorjectAdminName { set; get; }
        //public Guid PorjectAdminId { set; get; }
        ///// <summary>
        ///// 投标负责人
        ///// </summary>
        //public string BidAdminName { set; get; }
        //public Guid BidAdminId { set; get; }
        ///// <summary>
        ///// 投保参与人
        ///// </summary>
        //public String InsuranceAdminName { set; get; }
        //public Guid InsuranceAdminId { set; get; }
        /// <summary>
        /// 投标保证金
        /// </summary>
        
        public decimal BidSecurityFees { set; get; }
        /// <summary>
        /// 保证金收款账户
        /// </summary>       
        public string BidSecurityReceiveAccount { set; get; }
        /// <summary>
        /// 招标代理服务费
        /// </summary>
        public decimal AgentFees { set; get; }

        /// <summary>
        /// 退款
        /// </summary>
        public decimal Refund { set; get; }
        /// <summary>
        /// 保证退还时间
        /// </summary>
        public string BidSecurityReturnTime { set; get; }
        /// <summary>
        /// 联合体
        /// </summary>
        public string UnionOrganization { set; get; }
        /// <summary>
        /// 施工分包单位
        /// </summary>
        public string ConstructionSubcontractor { set; get; }
        /// <summary>
        /// 投标价格
        /// </summary>
        public decimal BidPrice { set; get; }
        /// <summary>
        /// 竞争对手
        /// </summary>
        public string Competitor { set; get; }
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 用户集合
        /// </summary>
        public ICollection<UserProject> UserProjects { set; get; }
    }

    public enum BidStatus {
        准备中=0,
        以投标=1,
        未中标=2,
        中标待启动=3,
        进行中未退保证金=4,
        进行中保证金已退=5,
        结项=6,
        其他=7
    }
}