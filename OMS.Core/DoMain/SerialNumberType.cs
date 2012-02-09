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
 /// SerialNumberType
 /// 序列号表
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
 [Table( "SerialNumber" )]
 [Serializable]
 public class SerialNumberType: ObjectBase<SerialNumberType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 名称
      ///</summary>
  public String FullName { get; set; }

      ///<summary>
      /// 序列号前缀
      ///</summary>
  public String Prefix { get; set; }

      ///<summary>
      /// 序列号分隔符
      ///</summary>
  public String Separator { get; set; }

      ///<summary>
      /// 升序序列
      ///</summary>
  public int Sequence { get; set; }

      ///<summary>
      /// 倒序序列
      ///</summary>
  public int Reduction { get; set; }

      ///<summary>
      /// 步骤
      ///</summary>
  public int Step { get; set; }

      ///<summary>
      /// 描述
      ///</summary>
  public String Description { get; set; }
  }
}
