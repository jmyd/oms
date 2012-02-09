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
 /// GoodsModifyRecordType
 /// 产品修改记录
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
 [Table( "GoodsModifyRecord" )]
 [Serializable]
 public class GoodsModifyRecordType: ObjectBase<GoodsModifyRecordType> 
 {

      ///<summary>
      /// 主键标识
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 修改人
      ///</summary>
  public String ModifyUserCode { get; set; }

      ///<summary>
      /// 修改时间
      ///</summary>
  public DateTime ModifyDate { get; set; }

      ///<summary>
      /// 修改字段
      ///</summary>
  public String ModifyField { get; set; }

      ///<summary>
      /// 修改前的值
      ///</summary>
  public String ModifyBeforeValue { get; set; }

      ///<summary>
      /// 修改后的值
      ///</summary>
  public String ModifyAfterValue { get; set; }
  }
}
