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
 /// TransportAreaCountryType
 /// 分区国家表
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
 [Table( "TransportAreaCountry" )]
 [Serializable]
 public class TransportAreaCountryType: ObjectBase<TransportAreaCountryType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 区域代码
      ///</summary>
  public String AreaCode { get; set; }

      ///<summary>
      /// 国家代码
      ///</summary>
  public String CountryCode { get; set; }
  }
}
