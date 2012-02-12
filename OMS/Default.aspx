<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OMS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="css/Default.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Applicetion.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($("#_Navigation")[0]) {
                if (window.location.hash) {
                    var arr = window.location.hash.split("_");
                    var mainEle = $("#_Menu_" + arr[0].substr(1))[0];
                    if (mainEle) {
                        var childItem = null;
                        for (var i = 0; i < mainEle.ChildArray.length; i++) {
                            if (mainEle.ChildArray[i][0] == arr[1]) {
                                childItem = "_ChildMenuItem_" + arr[1];
                                break;
                            }
                        }
                        if (childItem) {
                            mainEle.CurrentItem = childItem;
                            Application.onMainMenuClick(mainEle);
                        } else {
                            mainEle.CurrentItem = "_ChildMenuItem_" + mainEle.ChildArray[0];
                            Application.onMainMenuClick(mainEle);
                        }
                    } else {
                        Application.onMainMenuClick($("#_Navigation a")[0]);
                    }
                } else {
                    Application.onMainMenuClick($("#_Navigation a")[0]);
                }
            } else if (window.frameElement && window.frameElement.id == "_MainArea") {
                Page.mousedown(); //使用浏览器回退按钮时可能有控件未关闭
                if (!_DialogInstance && parent.Dialog._Array) {//可能有对话框未关闭
                    for (var i = 0; i < parent.Dialog._Array.length; i++) {
                        parent.$("_DialogDiv_" + parent.Dialog._Array[i]).outerHTML = "";
                        if (parent.$("#_AlertBGDiv")) {
                            parent.$("#_AlertBGDiv").hide();
                        }
                        if (parent.$("#_DialogBGDiv")) {
                            parent.$("#_DialogBGDiv").hide();
                        }
                    }
                }
            }
        });
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <table id="_TableHeader" width="100%" border="0" cellpadding="0" cellspacing="0"
        class="bluebg" style="background: #3388bb url(/Imgs/img/vistaBlue.jpg) repeat-x left top;">
        <tr>
            <td height="70" valign="bottom">
                <table height="70" border="0" cellpadding="0" cellspacing="0" style="position: relative;">
                    <tr>
                        <td style="padding: 0">
                            <img src="/Imgs/img/logo.gif">
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom" nowrap="nowrap">
                            <%-- <div style="float: left; background: url(/Imgs/img/selectsitebg.gif) no-repeat right top;
                                color: #666666; padding: 6px 23px 0 10px; margin-bottom: -2px;">
                            </div>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="bottom">
                <div style="text-align: right; margin: 0 20px 15px 0;">
                    当前用户：<b><asp:Literal ID="ltName" runat="server"></asp:Literal></b> &nbsp; |<asp:LinkButton
                        ID="lkOut" runat="server">退出登录</asp:LinkButton>
                    |<a href="javascript:void(0)" onclick="ChangePwd();">修改密码</a>
                </div>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center">
                            <div id="_Navigation" class="navigation">
                                <%--${Menu}--%>
                                <a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;" id="_Menu_120"
                                    class="current"><b>工作台</b></a><a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;"
                                        id="_Menu_122"><b>订单管理</b></a><a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;"
                                            id="_Menu_123"><b>库存管理</b></a><a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;"
                                                id="_Menu_124"><b>基础工具</b></a><a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;"
                                                    id="_Menu_125"><b>公司管理</b></a><a hidefocus="true" onclick="Application.onMainMenuClick(this);return false;"
                                                        id="_Menu_37"><b>系统管理</b></a>
                                <script type="text/javascript">

                                    var arr;
                                    arr = [];
                                    arr.push([129, "订单列表", "/Modules/Order/OrderList.aspx", "Icons/icon003a11.gif"]);
                                    arr.push([303, "订单扫描", "/framework/Module/OrderManage/OrderScanning.aspx", "Icons/icon018a4.gif"]);
                                    arr.push([341, "库存信息", "/framework/Module/GoodsManage/GoodsList.aspx", "Icons/icon402a1.gif"]);
                                    arr.push([397, "销售账户设置", "/framework/Module/Misc/AccountList.aspx", "Icons/icon050a18.gif"]);
                                    arr.push([394, "Paypal账户设置", "/framework/Module/Misc/PaypalAccountList.aspx", "Icons/icon050a14.gif"]);
                                    arr.push([131, "用户设置", "/framework/Module/Misc/UserInfo.aspx", "Icons/icon016a1.gif"]);
                                    arr.push([132, "公司设置", "/framework/Module/Misc/CompanyInfo.aspx", "Icons/icon028a7.gif"]);
                                    $('#_Menu_120').queue("ChildArray", arr);
                                    arr = [];
                                    arr.push([133, "订单列表", "/framework/Module/OrderManage/OrderList.aspx", "Icons/icon012a1.gif"]);
                                    arr.push([218, "订单扫描", "/framework/Module/OrderManage/OrderScanning.aspx", "Icons/icon051a1.gif"]);
                                    arr.push([342, "打印报关单", "/framework/Module/OrderManage/PrintDeclaration.aspx", "Icons/icon008a6.gif"]);
                                    arr.push([324, "配货批次", "/framework/Module/OrderManage/OrderPickingList.aspx", "Icons/icon029a15.gif"]);
                                    //                                    arr.push([137, "分包设置", "Site/Template.jsp", "Icons/icon018a1.gif"]);
                                    //                                    arr.push([161, "利润计算", "Site/Site.jsp", "Icons/icon040a1.gif"]);
                                    //                                    arr.push([346, "包裹管理", "Site/WorkBenchConfig.jsp", "Icons/icon001a7.gif"]);

                                    $('#_Menu_122').queue("ChildArray", arr);
                                    arr = [];
                                    arr.push([217, "库存管理", "/framework/Module/GoodsManage/GoodsList.aspx", "Icons/icon005a4.gif"]);
                                    arr.push([218, "入库管理", "/framework/Module/Stock/StockInList.aspx", "Icons/icon005a5.gif"]);
                                    arr.push([219, "出库管理", "/framework/Module/Stock/StockOutList.aspx", "Icons/icon005a6.gif"]);
                                    arr.push([146, "商品添加", "/framework/Module/GoodsManage/Goods.aspx", "Icons/icon032a1.gif"]);
                                    arr.push([144, "关系管理", "/framework/Module/GoodsManage/GoodsRele.aspx", "Icons/icon010a20.gif"]);
                                    arr.push([147, "ebay产品管理", "/framework/Module/Misc/EbayItemInformation.aspx", "Icons/icon010a11.gif"]);
                                    //                                    arr.push([148, "库存报警", "Stat/Summary.jsp", "Icons/icon031a1.gif"]);
                                    //                                    arr.push([150, "库存分析", "DataService/CommentMag.jsp", "Icons/icon018a4.gif"]);
                                    //                                    arr.push([151, "出库记录", "DataService/FullTextSearch.jsp", "Icons/icon033a4.gif"]);
                                    //                                    arr.push([325, "入库记录", "DataService/PublishStat.jsp", "Icons/icon018a4.gif"]);

                                    $('#_Menu_123').queue("ChildArray", arr);
                                    arr = [];
                                    arr.push([142, "订单分析", "/framework/Module/Analysis/OrderAnalysis.aspx", "Icons/icon030a1.gif"]);

                                    $('#_Menu_124').queue("ChildArray", arr);
                                    arr = [];
                                    arr.push([153, "公司信息管理", "/framework/Module/Misc/CompanyInfo.aspx", "Icons/icon007a10.gif"]);
                                    arr.push([157, "账户设置", "/framework/Module/Misc/AccountList.aspx", "Icons/icon007a16.gif"]);
                                    arr.push([159, "分单设置", "/framework/Module/Transport/TransportList.aspx", "Icons/icon007a14.gif"]);
                                    arr.push([159, "承运商设置", "/framework/Module/Transport/TransportModeList.aspx", "Icons/icon007a15.gif"]);
                                    arr.push([394, "Paypal账户设置", "/framework/Module/Misc/PaypalAccountList.aspx", "Icons/icon050a14.gif"]);

                                    $('#_Menu_125').queue("ChildArray", arr);
                                    arr = [];
                                    //                                    arr.push([38, "系统信息", "Platform/SysInfo.jsp", "Icons/icon002a1.gif"]);
                                    //                                    arr.push([39, "组织机构", "Platform/Branch.jsp", "Icons/icon042a1.gif"]);
                                    arr.push([40, "用户管理", "/framework/Module/Misc/UserInfo.aspx", "Icons/icon021a1.gif"]);
                                    //                                    arr.push([109, "角色管理", "Platform/Role.jsp", "Icons/icon025a1.gif"]);
                                    //                                    arr.push([45, "代码管理", "Platform/Code.jsp", "Icons/icon023a6.gif"]);
                                    //                                    arr.push([46, "配置项管理", "Platform/Config.jsp", "Icons/icon018a6.gif"]);
                                    //                                    arr.push([164, "定时计划", "Platform/Schedule.jsp", "Icons/icon020a1.gif"]);
                                    //                                    arr.push([339, "菜单管理", "Platform/Menu.jsp", "Icons/icon024a1.gif"]);
                                    //                                    arr.push([340, "用户日志", "Platform/UserLog.jsp", "Icons/icon025a5.gif"]);
                                    $('#_Menu_37').queue("ChildArray", arr);
                                </script>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="padding: 6px 3px 3px 3px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="2" height="2" style="background: url(/Imgs/img/jiao.gif) no-repeat right bottom;">
                        </td>
                        <td width="100%" id="_HMenutable" class="tabpageBar">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right" id="_VMenutable" class="verticalTabpageBar">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" valign="bottom">
                                        <div id="_ChildMenu">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="maintable" style="border-bottom: #999999 1px solid;
                                border-right: #999999 1px solid;">
                                <tr>
                                    <td>
                                        <iframe id='_MainArea' frameborder="0" width="100%" height="500" src='about:blank'
                                            scrolling="auto"></iframe>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
