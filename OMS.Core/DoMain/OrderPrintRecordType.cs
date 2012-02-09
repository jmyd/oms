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
 /// OrderPrintRecordType
 /// 订单打印记录表
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
 [Table( "OrderPrintRecord" )]
 [Serializable]
 public class OrderPrintRecordType: ObjectBase<OrderPrintRecordType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 订单编号
      ///</summary>
  public String OrderNo { get; set; }

      ///<summary>
      /// 订单标识
      ///</summary>
  public int OrderId { get; set; }

      ///<summary>
      /// 打印时间
      ///</summary>
  public DateTime CreateOn { get; set; }
  }
}
