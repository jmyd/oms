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
 /// EmailFieldType
 /// 邮件字段表
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
 [Table( "EmailField" )]
 [Serializable]
 public class EmailFieldType: ObjectBase<EmailFieldType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 字段代码
      ///</summary>
  public String FieldCode { get; set; }

      ///<summary>
      /// 字段名称
      ///</summary>
  public String FieldName { get; set; }

      ///<summary>
      /// 字段类
      ///</summary>
  public String FieldByClass { get; set; }
  }
}
