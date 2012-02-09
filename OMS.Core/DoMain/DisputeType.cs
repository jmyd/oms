//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , FeiDu TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using wojilu;
using wojilu.ORM;

namespace OMS.Core.DoMain
{

    /// <summary>
    /// DisputeInfo
    /// 纠纷表
    ///
    /// 修改纪录
    ///
    ///		2012-02-02 版本：1.0 XD 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XD</name>
    ///		<date>2012-02-02</date>
    /// </author>
    /// </summary>
    [Table("Dispute")]
    [Serializable]
    public class DisputeType : ObjectBase<DisputeType>
    {

        ///<summary>
        /// Id
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 平台
        ///</summary>
        public String PlatformName { get; set; }

        ///<summary>
        /// 账户
        ///</summary>
        public String SaleAccountName { get; set; }

        ///<summary>
        /// 订单编号
        ///</summary>
        public String OrderNo { get; set; }

        ///<summary>
        /// 订单代码
        ///</summary>
        public String OrderId { get; set; }

        ///<summary>
        /// 发货设置
        ///</summary>
        public DateTime SendOrderDate { get; set; }

        ///<summary>
        /// 产品代码
        ///</summary>
        public String ItemId { get; set; }

        ///<summary>
        /// 产品编号
        ///</summary>
        public String ItemNo { get; set; }

        ///<summary>
        /// 跟踪码
        ///</summary>
        public String TrackCode { get; set; }

        ///<summary>
        /// 运输方式
        ///</summary>
        public String TransportMode { get; set; }

        ///<summary>
        /// 纠纷类型
        ///</summary>
        public String DisputeCategory { get; set; }

        ///<summary>
        /// 纠纷小类型
        ///</summary>
        public String DisputeTypeCode { get; set; }

        ///<summary>
        /// 备足
        ///</summary>
        public String Remark { get; set; }

        ///<summary>
        /// 解决方式
        ///</summary>
        public String DisputeSolutionType { get; set; }

        ///<summary>
        /// 退款金额
        ///</summary>
        public Double RefundAmount { get; set; }

        ///<summary>
        /// 创建时间
        ///</summary>
        public DateTime CreateOn { get; set; }

        ///<summary>
        /// 纠纷状态
        ///</summary>
        public String DisputeStatus { get; set; }

        ///<summary>
        /// 解决时间
        ///</summary>
        public DateTime ResolutionTime { get; set; }

        ///<summary>
        /// 货币类型
        ///</summary>
        public String CurrencyCode { get; set; }
    }
}
