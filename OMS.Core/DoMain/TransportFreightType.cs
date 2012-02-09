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
 /// TransportFreightType
 /// 物流运费表
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
 [Table( "TransportFreight" )]
 [Serializable]
 public class TransportFreightType: ObjectBase<TransportFreightType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 分区代码
      ///</summary>
  public String AreaCode { get; set; }

      ///<summary>
      /// 物流代码
      ///</summary>
  public String TransportCode { get; set; }

      ///<summary>
      /// 首重
      ///</summary>
  public int BeginWeight { get; set; }

      ///<summary>
      /// 结束重量
      ///</summary>
  public int EndWeight { get; set; }

      ///<summary>
      /// 递增
      ///</summary>
  public int IncrementWeight { get; set; }

      ///<summary>
      /// 首重费用
      ///</summary>
  public Double FrisFreight { get; set; }

      ///<summary>
      /// 递增费用
      ///</summary>
  public Double IncrementFreight { get; set; }

      ///<summary>
      /// 处理费
      ///</summary>
  public Double ProcessingFee { get; set; }

      ///<summary>
      /// 折扣
      ///</summary>
  public Double Discount { get; set; }

      ///<summary>
      /// 处理费是否打折
      ///</summary>
  public int IsDiscountALL { get; set; }

      ///<summary>
      /// 备注
      ///</summary>
  public String Remark { get; set; }
  }
}
