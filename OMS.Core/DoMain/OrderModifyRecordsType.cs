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
 /// OrderModifyRecordsType
 /// 订单修改记录
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
 [Table( "OrderModifyRecords" )]
 [Serializable]
 public class OrderModifyRecordsType: ObjectBase<OrderModifyRecordsType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 订单代码
      ///</summary>
  public int OrderID { get; set; }

      ///<summary>
      /// 订单编号
      ///</summary>
  public String OrderNo { get; set; }

      ///<summary>
      /// 修改时间
      ///</summary>
  public DateTime OrderModifyDate { get; set; }

      ///<summary>
      /// 修改字段
      ///</summary>
  public String OrderModifyColumn { get; set; }

      ///<summary>
      /// 原来的值
      ///</summary>
  public String OrderModifyContent { get; set; }

      ///<summary>
      /// 修改后的值
      ///</summary>
  public String OrderModifyContent2 { get; set; }
  }
}
