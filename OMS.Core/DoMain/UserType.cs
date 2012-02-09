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
    /// UserType
    /// 用户表
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
    [Table("Users")]
    [Serializable]
    public class UserType : ObjectBase<UserType>
    {



        ///<summary>
        /// 用户名
        ///</summary>
        public String Username { get; set; }

        ///<summary>
        /// 真实名称
        ///</summary>
        public String Realname { get; set; }

        ///<summary>
        /// 公司代码
        ///</summary>
        public String CompanyCode { get; set; }

        ///<summary>
        /// 公司名称
        ///</summary>
        public String CompanyName { get; set; }

        ///<summary>
        /// 性别
        ///</summary>
        public String Sex { get; set; }

        ///<summary>
        /// 手机
        ///</summary>
        public String Mobile { get; set; }

        ///<summary>
        /// 生日
        ///</summary>
        public String Birthday { get; set; }

        ///<summary>
        /// 用户密码
        ///</summary>
        public String UserPassword { get; set; }

        ///<summary>
        /// Email
        ///</summary>
        public String Email { get; set; }

        ///<summary>
        /// 语言
        ///</summary>
        public String Lang { get; set; }

        ///<summary>
        /// 主题
        ///</summary>
        public String Theme { get; set; }

        ///<summary>
        /// 最后一次登录
        ///</summary>
        public DateTime LastVisit { get; set; }

        ///<summary>
        /// IPAddress
        ///</summary>
        public String IPAddress { get; set; }

        ///<summary>
        /// DeletionStateCode
        ///</summary>
        public int DeletionStateCode { get; set; }

        ///<summary>
        /// Enabled
        ///</summary>
        public int Enabled { get; set; }

        ///<summary>
        /// SortCode
        ///</summary>
        public int SortCode { get; set; }

        ///<summary>
        /// Description
        ///</summary>
        public String Description { get; set; }

        ///<summary>
        /// CreateOn
        ///</summary>
        public DateTime CreateOn { get; set; }

        ///<summary>
        /// CreateUserId
        ///</summary>
        public String CreateUserId { get; set; }

        ///<summary>
        /// CreateBy
        ///</summary>
        public String CreateBy { get; set; }

        ///<summary>
        /// ModifiedOn
        ///</summary>
        public DateTime ModifiedOn { get; set; }

        ///<summary>
        /// ModifiedUserId
        ///</summary>
        public String ModifiedUserId { get; set; }

        ///<summary>
        /// ModifiedBy
        ///</summary>
        public String ModifiedBy { get; set; }
    }
}
