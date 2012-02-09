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
 /// WarehouseType
 /// 仓库表
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
 [Table( "Warehouses" )]
 [Serializable]
 public class WarehouseType: ObjectBase<WarehouseType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 仓库名称
      ///</summary>
  public String WarehouseName { get; set; }

      ///<summary>
      /// 所在国家
      ///</summary>
  public String Country { get; set; }

      ///<summary>
      /// 所在省
      ///</summary>
  public String Province { get; set; }

      ///<summary>
      /// 所在市
      ///</summary>
  public String City { get; set; }
  }
}
