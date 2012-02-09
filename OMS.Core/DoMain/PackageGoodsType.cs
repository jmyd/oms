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
 /// PackageGoodsType
 /// 包裹产品表
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
 [Table( "PackageGoods" )]
 [Serializable]
 public class PackageGoodsType: ObjectBase<PackageGoodsType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 包裹号
      ///</summary>
  public String PackageNo { get; set; }

      ///<summary>
      /// 产品Sku
      ///</summary>
  public String Sku { get; set; }

      ///<summary>
      /// 产品数量
      ///</summary>
  public int ItemQty { get; set; }
  }
}
