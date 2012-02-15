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
    /// PrintTemplateType
    /// 打印模板表
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
    [Table("PrintTemplate")]
    [Serializable]
    public class PrintTemplateType : ObjectBase<PrintTemplateType>
    {



        ///<summary>
        /// 名称
        ///</summary>

        public String Name { get; set; }

        ///<summary>
        /// 模板内容
        ///</summary>
        [LongText]
        public String Content { get; set; }

        ///<summary>
        /// 备注
        ///</summary>
        public String Remark { get; set; }
    }
}
