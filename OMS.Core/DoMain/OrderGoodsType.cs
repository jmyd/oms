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
    /// OrderGoodsType
    /// 订单产品数据
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
    [Table("OrderGoods")]
    [Serializable]
    public class OrderGoodsType : ObjectBase<OrderGoodsType>
    {

        ///<summary>
        /// 主键标识
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 订单编号
        ///</summary>
        public String OrderNo { get; set; }

        ///<summary>
        /// 产品销售平台Code
        ///</summary>
        public String Sku { get; set; }

        ///<summary>
        /// 产品名称
        ///</summary>
        public String ItemName { get; set; }

        ///<summary>
        /// 产品内部编号
        ///</summary>
        public String ItemNo { get; set; }

        ///<summary>
        /// 销售价格
        ///</summary>
        public Double ItemPrice { get; set; }

        ///<summary>
        /// 产品图片
        ///</summary>
        public String ItemImg { get; set; }

        ///<summary>
        /// 产品数量
        ///</summary>
        public int ItemNum { get; set; }

        ///<summary>
        /// 产品属性
        ///</summary>
        public String ItemAttr { get; set; }

        ///<summary>
        /// 产品描述
        ///</summary>
        public String ItemDesc { get; set; }

        ///<summary>
        /// 产品缺货
        ///</summary>
        public int Enabled { get; set; }
    }
}
