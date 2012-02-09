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
 /// TransportAreaType
 /// 物流分区表
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
 [Table( "TransportArea" )]
 [Serializable]
 public class TransportAreaType: ObjectBase<TransportAreaType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 区域名称
      ///</summary>
  public String AreaName { get; set; }

      ///<summary>
      /// 物流方式
      ///</summary>
  public String TransportCode { get; set; }

      ///<summary>
      /// 物流名称
      ///</summary>
  public String TransportName { get; set; }
  }
}
