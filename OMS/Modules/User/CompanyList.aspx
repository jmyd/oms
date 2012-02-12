<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="OMS.Modules.User.CompanyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AddCompany() {
            $.dialog({ content: 'url:Company.aspx'
            });
        }


        function CheckDB(code) {
            $.dialog({ content: 'url:CheckDB.aspx?code=' + code
            });
        }
    </script>
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
                            <img src="/Imgs/Icons/icon018a1.gif" />公司列表
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                            <a href='javascript:void(0);' class='zPushBtn' onclick="AddCompany();">
                                <img src="/Imgs/Icons/icon018a4.gif" /><b>添加公司&nbsp;</b></a>
                        </td>
                    </tr>
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
                                    <td width="11%">
                                        <strong>操作</strong>
                                    </td>
                                    <td width="10%">
                                        <b>公司代码</b>
                                    </td>
                                    <td width="6%">
                                        <strong>公司名称</strong>
                                    </td>
                                    <td width="6%">
                                        <strong>付款时间</strong>
                                    </td>
                                    <td width="6%">
                                        <strong>剩余天数</strong>
                                    </td>
                                    <td width="5%">
                                        <strong>联系人</strong>
                                    </td>
                                    <td width="7%">
                                        <strong>联系电话</strong>
                                    </td>
                                    <td width="3%">
                                        <strong>地址</strong>
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rpOrder">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                编辑|删除|<a href="javascript:CheckDB('<%#Eval("Code")%>');">重置数据库</a>
                                            </td>
                                            <td>
                                                <%#Eval("Code")%>
                                            </td>
                                            <td>
                                                <%#Eval("FullName")%>
                                            </td>
                                            <td>
                                                <%#Eval("RechargeDate")%>
                                            </td>
                                            <td>
                                                <%#Eval("RechargeDay")%>
                                            </td>
                                            <td>
                                                <%#Eval("Manager")%>
                                            </td>
                                            <td>
                                                <%#Eval("InnerPhone")%>
                                            </td>
                                            <td>
                                                <%#Eval("Address")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="9" align="left" id="dg1_PageBar">
                                        <div style='float: right; font-family: Tahoma'>
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
