using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.Tools
{
    public enum PlatformType
    {
        Ebay,
        速卖通,
        亚马逊,
        B2C商城
    }

    public enum NowOrderType
    {
        合并,
        普通,
        分拆,
        多物品
    }

    public enum PayStatusType
    {
        已付款, 未付款
    }
}
