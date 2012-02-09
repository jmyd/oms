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
 /// FeedbackType
 /// 评价
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
 [Table( "Feedback" )]
 [Serializable]
 public class FeedbackType: ObjectBase<FeedbackType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 产品Id
      ///</summary>
  public String ItemId { get; set; }

      ///<summary>
      /// 评价类型
      ///</summary>
  public String NowFeedbackType { get; set; }

      ///<summary>
      /// 评价内容
      ///</summary>
  public String FeedbackContent { get; set; }

      ///<summary>
      /// 买家代码
      ///</summary>
  public String BuyerCode { get; set; }

      ///<summary>
      /// 买家好评数
      ///</summary>
  public int PositiveFeedbackCount { get; set; }

      ///<summary>
      /// 买家差评数
      ///</summary>
  public int NegativeFeedbackCount { get; set; }
  }
}
