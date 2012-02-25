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
    /// EmailReplied
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
    [Table("EmailReplied")]
    [Serializable]
    public class EmailRepliedType : ObjectBase<EmailRepliedType>
    {

        ///<summary>
        /// Id
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// 所属账号
        ///</summary>
        public String SaleAccount { get; set; }

        ///<summary>
        /// 邮件Id
        ///</summary>
        public String MessageID { get; set; }

        ///<summary>
        /// 邮件内容
        ///</summary>
        [Column(Length=2000)]
        public String Body { get; set; }

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
        public DateTime ReceiveOn { get; set; }

        ///<summary>
        /// 产品编号
        ///</summary>
        public String ItemID { get; set; }

        ///<summary>
        /// 回复人
        ///</summary>
        public String Replier { get; set; }

        ///<summary>
        /// 是否上传到ebay
        ///</summary>
        public bool IsToEbay { get; set; }

        ///<summary>
        /// 回复时间
        ///</summary>
        public DateTime CreateOn { get; set; }

        ///<summary>
        /// 上传到ebay时间
        ///</summary>
        
        public DateTime ToEbayOn { get; set; }

        ///<summary>
        /// 回复耗时(S)
        ///</summary>
        public Double ReplyCostSecond { get; set; }

        ///<summary>
        /// 收到至回复耗时(M)
        ///</summary>
        public Double RepliedSpaceHour { get; set; }
    }
}
