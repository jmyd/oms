<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailStatistic.aspx.cs" Inherits="OMS.Modules.Misc.EmailStatistic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>月邮件数量分析
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
                            <img src="/Imgs/Icons/icon018a1.gif" />月邮件数量分析
                        </td>
                    </tr>
                    <tr>
	                    <td class="info" align="left">
                        <table width="100%" border="0" style="color:#333333">
                            <tr>
                            <td align="left" colspan="2"><table width="100%" border="0" style="color:#333333">
                            <tr>
                            <td align="left" width="130"><asp:Button 
                                    ID="lbtnNowMonth" runat="server" Text="本月统计" onclick="lbtnNowMonth_Click"  /></td>
                            <td align="left" width="80" style="color:Black">历史统计：</td>
                            <td align="left" width="380"><asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>年<asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>月&nbsp;&nbsp; <asp:Button ID="btnSearch" runat="server" Text="查 询" onclick="btnSearch_Click"  /></td>
                            <td></td>
                            </tr>
                        </table></td>
                            </tr>
                        </table>
	                    </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                        <div id="div" runat="server" style="width:100%;background-color:#f1f1f1;"></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>        
    </table>
    </form>
</body>
</html>
