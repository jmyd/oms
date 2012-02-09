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
 /// TransportModeType
 /// 运输方式表
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
 [Table( "TransportMode" )]
 [Serializable]
 public class TransportModeType: ObjectBase<TransportModeType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 运输方式
      ///</summary>
  public String TransportName { get; set; }

      ///<summary>
      /// 运输类型
      ///</summary>
  public String TransportType { get; set; }

      ///<summary>
      /// 是否有追踪码
      ///</summary>
  public int HasTrackCode { get; set; }

      ///<summary>
      /// 备注
      ///</summary>
  public String Remark { get; set; }
  }
}
