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
    /// PackageType
    /// 包裹表
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
    [Table("Package")]
    [Serializable]
    public class PackageType : ObjectBase<PackageType>
    {

        ///<summary>
        /// Id
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 包裹号
        ///</summary>
        public String PackageNo { get; set; }

        ///<summary>
        /// 订单代码
        ///</summary>
        public int OrderID { get; set; }

        ///<summary>
        /// 订单编号
        ///</summary>
        public String OrderNo { get; set; }

        ///<summary>
        /// 包裹重量
        ///</summary>
        public Double PackageWeight { get; set; }

        ///<summary>
        /// 预计重量
        ///</summary>
        public Double ExpectedWeight { get; set; }

        ///<summary>
        /// 长
        ///</summary>
        public Double PackageLong { get; set; }

        ///<summary>
        /// 宽
        ///</summary>
        public Double PackageWide { get; set; }

        ///<summary>
        /// 高
        ///</summary>
        public Double PackageHigh { get; set; }

        ///<summary>
        /// 包裹状态
        ///</summary>
        public String PackageStatus { get; set; }

        ///<summary>
        /// 发货时间
        ///</summary>
        public DateTime ShippedTime { get; set; }

        ///<summary>
        /// 跟踪码
        ///</summary>
        public String TrackCode { get; set; }

        ///<summary>
        /// 物流方式
        ///</summary>
        public String LogisticsMode { get; set; }

        ///<summary>
        /// 创建时间
        ///</summary>
        public DateTime CreateOn { get; set; }
    }
}
