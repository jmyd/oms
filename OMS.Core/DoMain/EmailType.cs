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
    /// Email
    /// 纠纷表
    ///
    /// 修改纪录
    ///
    ///		2012-02-22 版本：1.0 HQ 创建。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XD</name>
    ///		<date>2012-02-22</date>
    /// </author>
    /// </summary>
    [Table("Email")]
    [Serializable]
    public class EmailType : ObjectBase<EmailType>
    {

        ///<summary>
        /// Id
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// 邮件Id
        ///</summary>
        public String MessageID { get; set; }

        ///<summary>
        /// 邮件内容
        ///</summary>
        [Column(Length = 2000)]
        public String Body { get; set; }

        ///<summary>
        /// 邮件类型
        ///</summary>
        public String MessageType { get; set; }

        ///<summary>
        /// 所属账号
        ///</summary>
        public String SaleAccount { get; set; }

        ///<summary>
        /// 买家邮箱
        ///</summary>
        public String BuyerEmail { get; set; }

        ///<summary>
        /// 买家账号
        ///</summary>
        public String BuyerAccount { get; set; }

        ///<summary>
        /// 邮件标题
        ///</summary>
        public String Subject { get; set; }

        ///<summary>
        /// 创建时间
        ///</summary>
        public DateTime CreateOn { get; set; }
        
        ///<summary>
        /// 邮件状态
        ///</summary>
        public String MessageStatus { get; set; }

        ///<summary>
        /// 产品编号
        ///</summary>
        public String ItemID { get; set; }

        ///<summary>
        /// 产品标题
        ///</summary>
        public String ItemTitle { get; set; }

        ///<summary>
        /// 产品价格
        ///</summary>
        public Double ItemPrice { get; set; }

        ///<summary>
        /// 产品价格货币种类
        ///</summary>        
        public String ItemPriceCurrency { get; set; }

        ///<summary>
        /// 产品链接地址
        ///</summary>
        public String ItemURL { get; set; }

        ///<summary>
        /// 排序号
        ///</summary>
        public Int32 SortNumber { get; set; }

        ///<summary>
        /// 上次回复人
        ///</summary>
        public String LastReplier { get; set; }
    }
}
