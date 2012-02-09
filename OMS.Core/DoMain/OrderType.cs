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
    /// OrderType
    /// 订单表
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
    [Table("Orders")]
    [Serializable]
    public class OrderType : ObjectBase<OrderType>
    {

        ///<summary>
        /// 主键标识
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 订单号（公司内部）
        ///</summary>
        public String OrderNo { get; set; }

        ///<summary>
        /// 订单号（销售平台）
        ///</summary>
        public String OrderExNo { get; set; }

        ///<summary>
        /// 银行交易号
        ///</summary>
        public String TxnId { get; set; }

        ///<summary>
        /// 订单类型
        ///</summary>
        public string NowOrderType { get; set; }

        ///<summary>
        /// 订单状态
        ///</summary>
        public string OrderStatus { get; set; }

        ///<summary>
        /// 发货状态
        ///</summary>
        public string ShippedStatus { get; set; }

        ///<summary>
        /// 是否付款
        ///</summary>
        public string PayStatus { get; set; }

        ///<summary>
        /// 是否打印
        ///</summary>
        public int IsPrint { get; set; }

        ///<summary>
        /// 打印次数
        ///</summary>
        public int PrintNum { get; set; }

        ///<summary>
        /// 订单金额
        ///</summary>
        public Double OrderAmount { get; set; }

        ///<summary>
        /// 货币
        ///</summary>
        public String OrderCurrencyCode { get; set; }

        ///<summary>
        /// 平台费用
        ///</summary>
        public Double OrderSaleTax { get; set; }

        ///<summary>
        /// 付款货币
        ///</summary>
        public String PayCurrencyCode { get; set; }

        ///<summary>
        /// 交易费
        ///</summary>
        public Double OrderPayTax { get; set; }

        ///<summary>
        /// 运输方式
        ///</summary>
        public String TransportMode { get; set; }

        ///<summary>
        /// 买家Id
        ///</summary>
        public String BuyerId { get; set; }

        ///<summary>
        /// 买家代码
        ///</summary>
        public String BuyerCode { get; set; }

        ///<summary>
        /// 买家Id
        ///</summary>
        public String AddressId { get; set; }

        ///<summary>
        /// 付款时间
        ///</summary>
        public DateTime PayTime { get; set; }

        ///<summary>
        /// 付款方式
        ///</summary>
        public String Payment { get; set; }

        ///<summary>
        /// 付款账号
        ///</summary>
        public String PayEmail { get; set; }

        ///<summary>
        /// 平台
        ///</summary>
        public String OrderForm { get; set; }

        ///<summary>
        /// 账号
        ///</summary>
        public String UserNameForm { get; set; }

        ///<summary>
        /// 订单备注
        ///</summary>
        [Column(Length = 800)]
        public String OrderNote { get; set; }

        ///<summary>
        /// 同步时间
        ///</summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 合并订单（合并订单填写被合并订单的集合）（被合并订单填写合并成订单的id）
        /// </summary>
        public string Mergerorders { get; set; }



        ///<summary>
        /// 是不是被合并订单
        ///</summary>
        public int Enabled { get; set; }

        ///<summary>
        /// 删除代码
        ///</summary>
        public int DeletionStateCode { get; set; }

        ///<summary>
        /// 排序码
        ///</summary>
        public int SortCode { get; set; }

        ///<summary>
        /// 描述
        ///</summary>
        public String Description { get; set; }

        ///<summary>
        /// 添加时间
        ///</summary>
        public DateTime CreateOn { get; set; }

        ///<summary>
        /// 添加人代码
        ///</summary>
        public String CreateUserId { get; set; }

        ///<summary>
        /// 添加人
        ///</summary>
        public String CreateBy { get; set; }

        ///<summary>
        /// 修改时间
        ///</summary>
        public DateTime ModifiedOn { get; set; }

        ///<summary>
        /// 修改人代码
        ///</summary>
        public String ModifiedUserId { get; set; }

        ///<summary>
        /// 修改人
        ///</summary>
        public String ModifiedBy { get; set; }


        /// <summary>
        /// 订单中的产品
        /// </summary>
        private List<OrderGoodsType> orderGoods;
        [NotSave]
        public List<OrderGoodsType> OrderGoods
        {
            get
            {
                if (orderGoods == null)
                    orderGoods = OrderGoodsType.find("OrderNo=:t1").set("t1", Id).list();
                if (orderGoods == null)
                    orderGoods = new List<OrderGoodsType>();
                return orderGoods;
            }
            set { orderGoods = value; }
        }
    }
}
