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
 /// StockInType
 /// 入库表
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
 [Table( "StockIn" )]
 [Serializable]
 public class StockInType: ObjectBase<StockInType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 入库时间
      ///</summary>
  public DateTime CreateOn { get; set; }

      ///<summary>
      /// Sku
      ///</summary>
  public String SKU { get; set; }

      ///<summary>
      /// 数量
      ///</summary>
  public int ItemNum { get; set; }

      ///<summary>
      /// 入库类型
      ///</summary>
  public String InType { get; set; }

      ///<summary>
      /// 入库状态
      ///</summary>
  public String InStatus { get; set; }

      ///<summary>
      /// 错误信息
      ///</summary>
  public String ErrorString { get; set; }
  }
}
