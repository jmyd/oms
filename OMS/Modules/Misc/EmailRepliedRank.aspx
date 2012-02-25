<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailRepliedRank.aspx.cs" Inherits="OMS.Modules.Misc.EmailRepliedRank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>回邮件数量排行榜
       </title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />  
    <script src="/Scripts/FusionCharts/FusionCharts.js" type="text/javascript"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tr valign="top">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="4" class="blockTable">                    
                    <tr>
                        <td valign="middle" class="blockTd">
                            <img src="/Imgs/Icons/icon018a1.gif" />回邮件数量排行榜
                        </td>
                    </tr>
                    <tr>
	                    <td style="padding: 0 8px 4px;">
                        <table width="100%" border="0" style="color:#333333">
                        <tr>
                        <td align="left" width="280"><asp:Button ID="btnNowDay" runat="server" Text="今日排行榜" 
                                onclick="btnNowDay_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                                ID="lbtnNowMonth" runat="server" Text="本月排行榜" onclick="lbtnNowMonth_Click"  /></td>
                        <td align="left" width="80" style="color:Black">历史排行榜：</td>
                        <td align="left" width="380"><asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>年<asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>月<asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>日(为0时表示按月查询)&nbsp;&nbsp; <asp:Button ID="btnSearch" runat="server" Text="查 询" onclick="btnSearch_Click"  /></td>
                        <td></td>
                        </tr>
                        </table>
	                    </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                        </td>
                    </tr>
                    <tr><td align="center" style=" background-color:#f1f1f1"><asp:Label runat="server" ID="lblTip"></asp:Label></td></tr>
                    <tr>
                        <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                            <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" valign="top" width="60%">
                                    <table width="100%" cellpadding="2" cellspacing="0" class="dataTable">
                                        <tr class="dataTableHead">
                                            <td width="3%" height="30">
                                            </td>
                                            <td>
                                                <strong>用户名</strong>
                                            </td>                                                                      
                                            <td>
                                                <strong>姓名</strong>
                                            </td>    
                                            <td>
                                                <strong>有效邮件数</strong>
                                            </td>   
                                            <td>
                                                <strong>回复平均用时</strong>
                                            </td>                                   
                                        </tr>
                                        <asp:Repeater runat="server" ID="rpRepliedList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Replier")%>
                                                    </td>                                         
                                                    <td>
                                                        <%# Eval("RealName")%>
                                                    </td>     
                                                    <td>
                                                        <%# Eval("Quantity")%>
                                                    </td>  
                                                    <td>
                                                        <%# Math.Ceiling(Convert.ToDouble(Eval("RCS")))%>
                                                    </td>  
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>                                
                                    </table>                                
                                </td>
                                <td align="left" valign="top"  width="40%">
                                <div id="divMail" runat="server" style="width:100%;background-color:#f1f1f1;"></div>
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

