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
    /// BuyerAddressType
    /// 买家地址表
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
    [Table("BuyerAddress")]
    [Serializable]
    public class BuyerAddressType : ObjectBase<BuyerAddressType>
    {

        ///<summary>
        /// 主键标识
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 买家代码
        ///</summary>
        public string BuyerId { get; set; }

        ///<summary>
        /// 买家名称
        ///</summary>
        public String BuyerCode { get; set; }

        ///<summary>
        /// 联系人
        ///</summary>
        public String ContactMan { get; set; }

        ///<summary>
        /// 邮编
        ///</summary>
        public String PostCode { get; set; }

        ///<summary>
        /// 电子邮箱
        ///</summary>
        public String Email { get; set; }

        ///<summary>
        /// 手机
        ///</summary>
        public String Phone { get; set; }

        ///<summary>
        /// 街道
        ///</summary>
        public String Street { get; set; }

        ///<summary>
        /// 县
        ///</summary>
        public String County { get; set; }

        ///<summary>
        /// 城市
        ///</summary>
        public String City { get; set; }

        ///<summary>
        /// 洲/省
        ///</summary>
        public String StateOrProvince { get; set; }

        ///<summary>
        /// 国家
        ///</summary>
        public String Country { get; set; }

        ///<summary>
        /// 国家代码
        ///</summary>
        public String CountryCode { get; set; }
    }
}
