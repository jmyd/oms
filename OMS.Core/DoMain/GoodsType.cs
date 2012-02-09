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
 /// GoodsType
 /// 产品表
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
 [Table( "Goods" )]
 [Serializable]
 public class GoodsType: ObjectBase<GoodsType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 产品编号
      ///</summary>
  public String ItemSku { get; set; }

      ///<summary>
      /// 产品英文名称
      ///</summary>
  public String ItemEName { get; set; }

      ///<summary>
      /// 产品中文名称
      ///</summary>
  public String ItemName { get; set; }

      ///<summary>
      /// 产品类型
      ///</summary>
  public String ItemType { get; set; }

      ///<summary>
      /// 产品型号
      ///</summary>
  public String ItemModel { get; set; }

      ///<summary>
      /// 产品颜色
      ///</summary>
  public String ItemColor { get; set; }

      ///<summary>
      /// 产品成本价
      ///</summary>
  public Double ItemPrice { get; set; }

      ///<summary>
      /// 产品重量
      ///</summary>
  public Double ItemWeight { get; set; }

      ///<summary>
      /// 长
      ///</summary>
  public Double ItemLong { get; set; }

      ///<summary>
      /// 宽
      ///</summary>
  public Double ItemWide { get; set; }

      ///<summary>
      /// 高
      ///</summary>
  public Double ItemHigh { get; set; }

      ///<summary>
      /// 产品现有数量
      ///</summary>
  public int ItemNum { get; set; }

      ///<summary>
      /// 预警下线
      ///</summary>
  public int ItemLower { get; set; }

      ///<summary>
      /// 所在仓库代码
      ///</summary>
  public String WarehouseCode { get; set; }

      ///<summary>
      /// 所在仓库名称
      ///</summary>
  public String WarehouseName { get; set; }

      ///<summary>
      /// 预警上线
      ///</summary>
  public int ItemUpper { get; set; }

      ///<summary>
      /// Description
      ///</summary>
  public String Description { get; set; }

      ///<summary>
      /// DeletionStateCode
      ///</summary>
  public int DeletionStateCode { get; set; }

      ///<summary>
      /// Enabled
      ///</summary>
  public int Enabled { get; set; }

      ///<summary>
      /// SortCode
      ///</summary>
  public int SortCode { get; set; }

      ///<summary>
      /// CreateOn
      ///</summary>
  public DateTime CreateOn { get; set; }

      ///<summary>
      /// CreateUserId
      ///</summary>
  public String CreateUserId { get; set; }

      ///<summary>
      /// CreateBy
      ///</summary>
  public String CreateBy { get; set; }

      ///<summary>
      /// ModifiedOn
      ///</summary>
  public DateTime ModifiedOn { get; set; }

      ///<summary>
      /// ModifiedUserId
      ///</summary>
  public String ModifiedUserId { get; set; }

      ///<summary>
      /// ModifiedBy
      ///</summary>
  public String ModifiedBy { get; set; }
  }
}
