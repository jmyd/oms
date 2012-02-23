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
    /// SaleAccountType
    /// 销售账户表
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
    [Table("SaleAccount")]
    [Serializable]
    public class SaleAccountType : ObjectBase<SaleAccountType>
    {

        ///<summary>
        /// Id
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 用户名
        ///</summary>
        public String UserName { get; set; }

        ///<summary>
        /// 复制人
        ///</summary>
        public String AccountManager { get; set; }

        ///<summary>
        /// 电话
        ///</summary>
        public String ManagerPhone { get; set; }

        ///<summary>
        /// Email
        ///</summary>
        public String ManagerEmail { get; set; }

        ///<summary>
        /// ApiToken
        ///</summary>
        public String ApiToken { get; set; }

        ///<summary>
        /// 描述
        ///</summary>
        public String Description { get; set; }

        ///<summary>
        /// 账户状态
        ///</summary>
        public String AccountStatus { get; set; }

        ///<summary>
        /// 平台账户
        ///</summary>
        public String PlatformCode { get; set; }
    }
}
