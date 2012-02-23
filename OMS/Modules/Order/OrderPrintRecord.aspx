<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPrintRecord.aspx.cs"
    Inherits="OMS.Modules.Order.OrderPrintRecord" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单打印记录</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tr valign="top">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="4" class="blockTable">
                    <tr>
                        <td colspan="2" valign="middle" class="blockTd">
                            <img src="/Imgs/Icons/icon018a1.gif" />打印记录
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                            <asp:Repeater runat="server" ID="rpRecord">
                                <ItemTemplate>
                                    <div style="width: 500px; float: left;">
                                        <table width="400" cellpadding="2" cellspacing="0" class="dataTable" id="Table1">
                                            <tr class="dataTableHead">
                                                <td width="80" align="right">
                                                    <strong>标题:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("Title") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>条件:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("OrderCondition")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>订单数:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("OrderNum")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>操作</strong>
                                                </td>
                                                <td>
                                                    <input value="包裹单打印" type="button" onclick="window.open('/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>')" />
                                                    <input value="包裹单打印" type="button" onclick="window.open('/Modules/Print/PrintReport/PrintReport.aspx?Report=ParcelA4&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>')" /><br />
                                                    <a href='/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>'>
                                                        多物品打印</a> <a href='/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>'>
                                                            报关单打印</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div style="width: 400; float: left;">
                                        <table width="400" cellpadding="2" cellspacing="0" class="dataTable" id="Table1">
                                            <tr class="dataTableHead">
                                                <td width="80" align="right">
                                                    <strong>标题:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("Title") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>条件:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("OrderCondition")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>订单数:</strong>
                                                </td>
                                                <td>
                                                    <%#Eval("OrderNum")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>操作</strong>
                                                </td>
                                                <td>
                                                    <a href='/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>'>
                                                        包裹单打印</a> <a href='/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>'>
                                                            多物品打印</a> <a href='/Modules/Print/PrintReport/PrintReport.aspx?Report=Parcel&Data=/Modules/Print/Data/xmlParcel.aspx?id=<%#Eval("Id")%>'>
                                                                报关单打印</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                            <div style="clear: both;">
                            </div>
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
    </form>
</body>
</html>
