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
 /// BuyerType
 /// 买家表
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
 [Table( "Buyers" )]
 [Serializable]
 public class BuyerType: ObjectBase<BuyerType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 买家代码
      ///</summary>
  public String BuyerCode { get; set; }

      ///<summary>
      /// 平台
      ///</summary>
  public String PlatformCode { get; set; }

      ///<summary>
      /// 买家级别
      ///</summary>
  public int BuyerLevel { get; set; }

      ///<summary>
      /// 买家购买次数
      ///</summary>
  public int BuyCount { get; set; }
  }
}
