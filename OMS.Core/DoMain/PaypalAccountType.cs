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
 /// PaypalAccountType
 /// Paypal账户表
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
 [Table( "PaypalAccount" )]
 [Serializable]
 public class PaypalAccountType: ObjectBase<PaypalAccountType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 用户名
      ///</summary>
  public String UserName { get; set; }

      ///<summary>
      /// API键
      ///</summary>
  public String APIKEY { get; set; }

      ///<summary>
      /// API密码
      ///</summary>
  public String APIPWD { get; set; }

      ///<summary>
      /// API Token
      ///</summary>
  public String ApiToken { get; set; }

      ///<summary>
      /// 描述
      ///</summary>
  public String Description { get; set; }

      ///<summary>
      /// 账户状态
      ///</summary>
  public String AccountStatus { get; set; }
  }
}
