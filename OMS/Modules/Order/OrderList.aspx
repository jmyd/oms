<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="OMS.Modules.Order.OrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AddOrderByAPI() {
            $.dialog({ content: 'url:AddOrderByAPI.aspx' });
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
    <asp:HiddenField ID="hkey" runat="server" />
    <asp:HiddenField ID="hstatus" runat="server" />
    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tr valign="top">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="4" class="blockTable">
                    <tr>
                        <td colspan="2" valign="middle" class="blockTd">
                            <img src="/Imgs/Icons/icon018a1.gif" />订单列表
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                            <a href='javascript:AddOrderByAPI();' class='zPushBtn'>
                                <img src="/Imgs/Icons/icon018a4.gif" /><b>订单同步&nbsp;</b></a> <a href='javascript:void(0);'
                                    class='zPushBtn' id='a1' onclick="AddOrder();">
                                    <img src="/Imgs/Icons/icon018a16.gif" width="20" height="20" /><b>订单添加&nbsp;</b></a>
                            <a href='javascript:void(0);' ztype='zPushBtn' class='zPushBtn' hidefocus='true'
                                tabindex='-1' onselectstart='return false' id='a2' onclick="OrderGoodsSetup();">
                                <img src="/Imgs/Icons/icon018a3.gif" /><b>订单产品系数设置&nbsp;</b></a>
                            <asp:LinkButton ID="lbMerger" runat="server" class='zPushBtn'>
                                    <img src="/Imgs/Icons/icon_column.gif" width="20" height="20" /><b>订单合并&nbsp;</b></asp:LinkButton>
                            <asp:LinkButton ID="lbPicking" runat="server" hidefocus="true" onselectstart="return false"
                                TabIndex="-1" class="zPushBtn">  <img src="/Imgs/Icons/icon018a5.gif"><b>添加订单到批次&nbsp;</b></asp:LinkButton>
                            <a href='javascript:void(0);' ztype='zPushBtn' class='zPushBtn' hidefocus='true'
                                tabindex='-1' id='ImportOrder' onclick="ImportOrder(this);">
                                <img src="/Imgs/Icons/icon042a1.gif" width="20" height="20" /><b>订单导入&nbsp;</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                            所属平台:
                            <asp:DropDownList ID="ddlPlatform" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            所属账号:
                            <asp:DropDownList ID="ddlAccount" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;订单状态:
                            <asp:DropDownList ID="ddlOrderStatus" runat="server">
                            </asp:DropDownList>
                            <input name="Keyword" type="text" id="txtSearch" value="" runat="server" style="width: 160px">
                            <asp:Button Text="查询" ID="btnSearch" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                            <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" sortstring=""
                                id="Table1" page="true" size="0" multiselect="true" autofill="true" scroll="false"
                                lazy="false" cachesize="0">
                                <tr ztype="head" class="dataTableHead">
                                    <td width="3%" height="30" ztype="RowNo">
                                        &nbsp;
                                    </td>
                                    <td width="11%">
                                        <strong>操作</strong>
                                    </td>
                                    <td width="10%">
                                        <b>订单编号</b>
                                    </td>
                                    <td width="6%">
                                        <strong>同步时间</strong>
                                    </td>
                                    <td width="6%">
                                        <strong>付款时间</strong>
                                    </td>
                                    <td width="6%">
                                        <strong>发货时间</strong>
                                    </td>
                                    <td width="5%">
                                        <strong>货币</strong>
                                    </td>
                                    <td width="7%">
                                        <strong>订单费用</strong>
                                    </td>
                                    <td width="3%">
                                        <strong>pp</strong>
                                    </td>
                                    <td width="6%">
                                        <strong>订单状态</strong>
                                    </td>
                                    <td width="8%">
                                        <strong>挂号</strong>
                                    </td>
                                    <td width="5%">
                                        <strong>平台</strong>
                                    </td>
                                    <td width="8%">
                                        <strong>所属账号</strong>
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rpOrder">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <a href='PackageList.aspx?id=<%#Eval("Id") %>' target="_blank">查看包裹</a>|<a href='/framework/Module/Print/PrintReport/PrintReport.aspx?report=paypalAddress.grf&data=/framework/Module/Print/Data/xmlOrder.aspx?oid=<%#Eval("Id") %>'
                                                    target="_blank">包裹单</a>
                                            </td>
                                            <td>
                                                <a href='Order.Aspx?oid=<%#Eval("Id") %>' target="_blank">
                                                    <%#Eval("TxnId")%></a>
                                            </td>
                                            <td>
                                                <%#Eval("CreateOn", "{0:d}")%>
                                            </td>
                                            <td>
                                                <%#Eval("PayOrderTime", "{0:d}")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderStatus").ToString()=="2"?"":Eval("SendOrderTIme", "{0:d}")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderCurrencyCode")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderAmount")%>
                                            </td>
                                            <td>
                                                <%#Eval("AddressId").ToString()=="1"?"√":"×"%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderStatus").ToString()=="2"?"待发货":"已发货"%>
                                            </td>
                                            <td>
                                                <%#Eval("TransportMode")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderForm")%>
                                            </td>
                                            <td>
                                                <%#Eval("UserNameForm")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="13" align="left" id="dg1_PageBar">
                                        <div style='float: right; font-family: Tahoma'>
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb"
                                                FirstPageText="第一页" LastPageText="最末页" NextPageText="下一页" PagingButtonLayoutType="None"
                                                PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
                                        </div>
                                        <div style='float: left; font-family: Tahoma'>
                                        </div>
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
