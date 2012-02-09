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
 /// CompanyType
 /// 公司表
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
 [Table( "Company" )]
 [Serializable]
 public class CompanyType: ObjectBase<CompanyType> 
 {

      ///<summary>
      /// Id
      ///</summary>
  //public int Id { get; set; }

      ///<summary>
      /// 公司代码（用户登录用）
      ///</summary>
  public String Code { get; set; }

      ///<summary>
      /// 简称
      ///</summary>
  public String ShortName { get; set; }

      ///<summary>
      /// 全名
      ///</summary>
  public String FullName { get; set; }

      ///<summary>
      /// 分类
      ///</summary>
  public String Category { get; set; }

      ///<summary>
      /// 公司电话
      ///</summary>
  public String InnerPhone { get; set; }

      ///<summary>
      /// 传真
      ///</summary>
  public String Fax { get; set; }

      ///<summary>
      /// 邮编
      ///</summary>
  public String Postalcode { get; set; }

      ///<summary>
      /// 地址
      ///</summary>
  public String Address { get; set; }

      ///<summary>
      /// 网址
      ///</summary>
  public String Web { get; set; }

      ///<summary>
      /// 负责人
      ///</summary>
  public String Manager { get; set; }

      ///<summary>
      /// 副负责人
      ///</summary>
  public String AssistantManager { get; set; }

      ///<summary>
      /// 充值时间
      ///</summary>
  public DateTime RechargeDate { get; set; }

      ///<summary>
      /// 充值天数
      ///</summary>
  public int RechargeDay { get; set; }

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
      /// Description
      ///</summary>
  public String Description { get; set; }

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
