<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepliedEmailList.aspx.cs" Inherits="OMS.Modules.Misc.RepliedEmailList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer"  TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>已回邮件列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Edit(url) {
            $.dialog({ width: 1000, height: 480, title: '邮件', content: url
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
                            <img src="/Imgs/Icons/icon018a1.gif" />已回邮件列表
                        </td>
                    </tr>
                    <tr>
	                    <td>
                        <table width="100%" border="0">
                            <tr>
                            <td align="left">平台账号&nbsp;-&nbsp;<%=accountLink%></td>
                            </tr>
                        </table>
	                    </td>
                    </tr>
                    <tr>
	                    <td align="left"><table width="100%" border="0" style="color:#333333">
                        <tr>
                        <td align="left">时间段：<input type="text" class="inputText" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly" style=" width:66px;" />&nbsp;<asp:TextBox ID="txtStartHour" runat="server" Width="17" CssClass="textBox"></asp:TextBox> 时&nbsp;—&nbsp;<input type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly" class="inputText" style=" width:66px;"/>&nbsp;<asp:TextBox ID="txtEndHour" runat="server" Width="17"  CssClass="textBox"></asp:TextBox> 时&nbsp;&nbsp;&nbsp;&nbsp;Ebay账号：<asp:TextBox ID="txtSenderId" runat="server" CssClass="textBox" Width="108"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;关键字：<asp:TextBox ID="txtSearchKey" runat="server" CssClass="textBox" Width="299"></asp:TextBox>&nbsp;<asp:Button ID="btnSearch" runat="server" Text="刷新/查询" onclick="btnSearch_Click" /></td>
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
                                        <strong>回复人</strong>
                                    </td>    
                                    <td>
                                        <strong>内容摘要</strong>
                                    </td>
                                    <td>
                                        <strong>回复时间</strong>
                                    </td>
                                    <td>
                                        <strong>回复用时</strong>
                                    </td>
                                    <td>
                                        <strong>是否上传</strong>
                                    </td>
                                    <td>
                                        <strong>上传时间</strong>
                                    </td>
                                    <td>
                                        <strong>间隔时间</strong>
                                    </td>                                    
                                </tr>
                                <asp:Repeater runat="server" ID="rpEmail" onitemdatabound="rpEmial_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <%# Eval("Replier")%>
                                            </td>                                            
                                            <td>
                                                <asp:Label ID="lblBody" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("CreateOn")%>
                                            </td>
                                            <td>
                                                <%# Math.Ceiling(Convert.ToDouble(Eval("ReplyCostSecond")))%>s
                                            </td>
                                            <td>
                                                <%# Convert.ToBoolean(Eval("IsToEbay"))?"是":"否"%>
                                            </td>   
                                            <td>
                                                <%# Convert.ToDateTime(Eval("ToEbayOn")) > new DateTime(1999, 1, 1) ? Eval("ToEbayOn") : ""%>
                                            </td>
                                            <td>
                                                <%# Math.Ceiling(Convert.ToDouble(Eval("RepliedSpaceHour")))%>H
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
