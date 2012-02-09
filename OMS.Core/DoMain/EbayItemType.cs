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
 /// EbayItemType
 /// Ebay产品信息
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
 [Table( "EbayItem" )]
 [Serializable]
 public class EbayItemType: ObjectBase<EbayItemType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 产品ID
      ///</summary>
  public String ItemId { get; set; }

      ///<summary>
      /// 标题
      ///</summary>
  public String ItemTitle { get; set; }

      ///<summary>
      /// 货币
      ///</summary>
  public String CurrencyID { get; set; }

      ///<summary>
      /// 价格
      ///</summary>
  public String ItemPrice { get; set; }

      ///<summary>
      /// 图片地址
      ///</summary>
  public String PictureURL { get; set; }

      ///<summary>
      /// 总挂贴数
      ///</summary>
  public int BeginNum { get; set; }

      ///<summary>
      /// 现在库存
      ///</summary>
  public int NowNum { get; set; }

      ///<summary>
      /// 产品链接
      ///</summary>
  public String ItemURL { get; set; }

      ///<summary>
      /// 挂贴时间
      ///</summary>
  public DateTime StartTime { get; set; }

      ///<summary>
      /// 更新时间
      ///</summary>
  public DateTime CreateOn { get; set; }

      ///<summary>
      /// 账户
      ///</summary>
  public String AccountFrom { get; set; }
  }
}
