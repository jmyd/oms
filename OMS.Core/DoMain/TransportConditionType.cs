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
 /// TransportConditionType
 /// 物流设置条件表
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
 [Table( "TransportCondition" )]
 [Serializable]
 public class TransportConditionType: ObjectBase<TransportConditionType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 条件标题
      ///</summary>
  public String Title { get; set; }

      ///<summary>
      /// 条件值
      ///</summary>
  public String TransportValue { get; set; }

      ///<summary>
      /// 参数
      ///</summary>
  public String TransportArgs { get; set; }

      ///<summary>
      /// 判断方式
      ///</summary>
  public String TransportCondition { get; set; }

      ///<summary>
      /// 优先级
      ///</summary>
  public int Priority { get; set; }

      ///<summary>
      /// 物流方式
      ///</summary>
  public String TransportCode { get; set; }

      ///<summary>
      /// 平台代码
      ///</summary>
  public String PlatformCode { get; set; }

      ///<summary>
      /// 备注
      ///</summary>
  public String Remark { get; set; }
  }
}
