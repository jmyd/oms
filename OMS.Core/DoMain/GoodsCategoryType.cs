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
 /// GoodsCategoryType
 /// 产品分类
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
 [Table( "GoodsCategory" )]
 [Serializable]
 public class GoodsCategoryType: ObjectBase<GoodsCategoryType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 分类名称
      ///</summary>
  public String CategoryName { get; set; }

      ///<summary>
      /// 分类英文名
      ///</summary>
  public String CategoryEName { get; set; }

      ///<summary>
      /// 描述
      ///</summary>
  public String Description { get; set; }
  }
}
