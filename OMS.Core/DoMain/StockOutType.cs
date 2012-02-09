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
 /// StockOutType
 /// 出库表
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
 [Table( "StockOut" )]
 [Serializable]
 public class StockOutType: ObjectBase<StockOutType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// CompanyId
      ///</summary>
  public String CompanyId { get; set; }

      ///<summary>
      /// OrderNo
      ///</summary>
  public String OrderNo { get; set; }

      ///<summary>
      /// OrderId
      ///</summary>
  public String OrderId { get; set; }

      ///<summary>
      /// ItemNo
      ///</summary>
  public String ItemNo { get; set; }

      ///<summary>
      /// ItemNum
      ///</summary>
  public int ItemNum { get; set; }

      ///<summary>
      /// CreateOn
      ///</summary>
  public DateTime CreateOn { get; set; }

      ///<summary>
      /// OutStatus
      ///</summary>
  public String OutStatus { get; set; }

      ///<summary>
      /// OutType
      ///</summary>
  public String OutType { get; set; }

      ///<summary>
      /// ErrorString
      ///</summary>
  public String ErrorString { get; set; }
  }
}
