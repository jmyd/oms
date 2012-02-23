<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailList.aspx.cs" Inherits="OMS.Modules.Misc.EmailList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer"  TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>邮件列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Reply(id) {
            $.dialog({width:1024, height:600, title:'回邮件', content:'url:Reply.aspx?id=' + id,
               
            });
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hdEbayAccount" />
    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tr valign="top">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="4" class="blockTable">                    
                    <tr>
                        <td valign="middle" class="blockTd">
                            <img src="/Imgs/Icons/icon018a1.gif" />待回邮件列表
                        </td>
                    </tr>
                    <tr>
	                    <td class="info" align="left">
                        <table width="100%" border="0" style="color:#333333">
                            <tr>
                            <td align="left" width="50%">平台账号&nbsp;-&nbsp;<%=accountLink%></td><td align="left" width="50%">邮件类型：<asp:DropDownList 
                                    ID="ddlEmailType" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="btnSearch_Click">
                                    <asp:ListItem Text="全部" Value="0" style="color:red;"></asp:ListItem>
                                    <asp:ListItem Text="24小时内有订单" Value="50" style="color:red;"></asp:ListItem>
                                    <asp:ListItem Text="订单产品有颜色" Value="40" style="color:#CC3300;"></asp:ListItem>
                                    <asp:ListItem Text="质量问题" Value="30" style="color:#0033CC;"></asp:ListItem>
                                    <asp:ListItem Text="重要客户" Value="20" style="color:#9900CC;"></asp:ListItem>                            
                                    </asp:DropDownList>
         </td>
                            </tr>
                        </table>
	                    </td>
                    </tr>
                    <tr>
	                    <td align="left"><table width="100%" border="0" style="color:#333333">
                        <tr>
                        <td align="left">时间段：<input type="text" class="inputText" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly" style=" width:66px;" />&nbsp;<asp:TextBox ID="txtStartHour" runat="server" Width="17" CssClass="textBox"></asp:TextBox> 时—<input type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly" class="inputText" style=" width:66px;"/>&nbsp;<asp:TextBox ID="txtEndHour" runat="server" Width="17"  CssClass="textBox"></asp:TextBox> 时&nbsp;&nbsp;Ebay账号：<asp:TextBox ID="txtSenderId" runat="server" CssClass="textBox" Width="82"></asp:TextBox>&nbsp;&nbsp;关键字：<asp:TextBox ID="txtSearchKey" runat="server" CssClass="textBox" Width="183"></asp:TextBox>&nbsp;<asp:Button ID="btnSearch" runat="server" Text="刷新/查询" onclick="btnSearch_Click" /></td>
                        </tr>
                        </table></td></tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                            <table width="100%" cellpadding="2" cellspacing="0" class="dataTable">
                                <tr class="dataTableHead">
                                    <td width="3%" height="30">
                                    </td>
                                    <td>
                                        <strong>Ebay账号</strong>
                                    </td>                                    
                                    <td>
                                        <strong>客户账号</strong>
                                    </td>
                                    <td>
                                        <strong>内容摘要</strong>
                                    </td>
                                    <td>
                                        <strong>上次回复人</strong>
                                    </td>
                                    <td>
                                        <strong>收到时间</strong>
                                    </td>
                                    <td>
                                        <strong>重要客户</strong>
                                    </td>                                    
                                </tr>
                                <asp:Repeater runat="server" ID="rpEmail" onitemcreated="rpEmial_ItemCreated"  onitemdatabound="rpEmial_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <%# Eval("SaleAccount")%>
                                            </td>
                                            <td>
                                                <%# Eval("BuyerAccount")%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBody" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("LastReplier")%>
                                            </td>
                                            <td>
                                                <%# Eval("CreateOn")%>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdEmailId" runat="server" Value='<%# Eval("Id") %>' /><asp:Button runat="server" ID="btnSetImportant"  />
                                            </td>                                        
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="7" align="left" id="dg1_PageBar">
                                        <div style='float: right; font-family: Tahoma'>
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb"
                                                FirstPageText="第一页" LastPageText="最末页" NextPageText="下一页" PagingButtonLayoutType="None" SubmitButtonText="Go" ShowBoxThreshold="11" PrevPageText="上一页" CustomInfoHTML="共 %PageCount% 页， %RecordCount% 条记录" OnPageChanged="AspNetPager1_PageChanged">
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
