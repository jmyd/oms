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
    /// GoodsCoefficientType
    /// 产品对应系数表
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
    [Table("GoodsCoefficient")]
    [Serializable]
    public class GoodsCoefficientType : ObjectBase<GoodsCoefficientType>
    {

        ///<summary>
        /// Id
        ///</summary>
        //public int Id { get; set; }

        ///<summary>
        /// 平台sku
        ///</summary>
        public String SaleSku { get; set; }

        ///<summary>
        /// 内部产品Sku
        ///</summary>
        public String ItemSku { get; set; }

        ///<summary>
        /// 描述
        ///</summary>
        public String Description { get; set; }

        ///<summary>
        /// 产品数量
        ///</summary>
        public int GoodsNum { get; set; }
    }
}
