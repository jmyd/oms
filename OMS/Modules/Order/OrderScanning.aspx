<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderScanning.aspx.cs"
    Inherits="OMS.Modules.Order.OrderScanning" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单扫描</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellspacing="6" cellpadding="0" border="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tbody>
            <tr valign="top">
                <td>
                    <table width="100%" cellspacing="0" cellpadding="6" border="0" class="blockTable">
                        <tbody>
                            <tr>
                                <td valign="middle" class="blockTd">
                                    <img src="/static/img/Icons/icon021a1.gif">
                                    订单扫描
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0 8px 4px;">
                                    快递方式:<asp:DropDownList ID="ddlTransportMode" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="checkbox" id='ckBGD' value="报关单打印" />报关单打印
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                                    <asp:UpdateProgress ID="listDetailPress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <h3>
                                                数据加载中，请稍后</h3>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <table cellspacing="0" cellpadding="1" bordercolor="#eeeeee" border="1" width="100%">
                                                    <tbody>
                                                        <tr id="tr_ID">
                                                            <td height="25" width="22%">
                                                                <h2>
                                                                    <b>扫描订单</b></h2>
                                                            </td>
                                                            <td width="78%">
                                                                <asp:TextBox ID="txtKey" runat="server" onkeydown="keydown(event);" Style="font-size: 50px;
                                                                    background-image: none;" Width="511px" AutoCompleteType="Disabled"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr2">
                                                            <td height="25" width="22%">
                                                                <h2>
                                                                    信息</h2>
                                                                <asp:HiddenField ID="hpid" runat="server" Value="" />
                                                                <asp:HiddenField ID="hact" runat="server" Value="a" />
                                                                <asp:HiddenField ID="hoid" runat="server" Value="" />
                                                                <asp:HiddenField ID="hNoTrackCode" runat="server" />
                                                            </td>
                                                            <td width="78%">
                                                                <font style="color: Red; font-size: 30px">
                                                                    <asp:Literal ID="Literal1" runat="server" Text="等待扫描"></asp:Literal></font>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr1">
                                                            <td height="25" width="22%">
                                                                <h2>
                                                                    订单信息</h2>
                                                            </td>
                                                            <td width="78%">
                                                                订单重量:<asp:TextBox ID="txtweight" runat="server" AutoCompleteType="Disabled" Text=""
                                                                    onkeydown="keydown12(event);"></asp:TextBox>
                                                                <span id="txtError"></span>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <table cellspacing="0" cellpadding="1" bordercolor="#eeeeee" border="1" width="100%">
                                            <tbody>
                                                <tr id="tr3">
                                                    <td height="200" width="22%">
                                                        <h2>
                                                            <b>扫描订单</b></h2>
                                                    </td>
                                                    <td width="78%">
                                                        <textarea id="txtOrders" runat="server" style="width: 511px; height: 200px;"></textarea>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <script type="text/javascript">

        SetInit();
    </script>
</body>
</html>
