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
    [Table("EbayOrderID")]
    [Serializable]
    public class EbayOrderIDType : ObjectBase<EbayOrderIDType>
    {
        /// <summary>
        /// 
        /// 交易号
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ItemID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn;

        /// <summary>
        /// 是否使用
        /// </summary>
        public int IsUse { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime UseDate { get; set; }
    }
}
