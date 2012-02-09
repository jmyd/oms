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
 /// DisputeCategoryType
 /// 纠纷分类表
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
 [Table( "DisputeCategory" )]
 [Serializable]
 public class DisputeCategoryType: ObjectBase<DisputeCategoryType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 类型名称
      ///</summary>
  public String CateName { get; set; }
  }
}
