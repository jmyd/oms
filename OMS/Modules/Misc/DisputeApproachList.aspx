<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisputeApproachList.aspx.cs" Inherits="OMS.Modules.Misc.DisputeApproachList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>纠纷处理方式列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AddDisputeApproach() {
            $.dialog({ content: 'url:DisputeApproach.aspx'
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
                            <img src="/Imgs/Icons/icon018a1.gif" />纠纷处理方式列表
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">                            
                            <a href='javascript:void(0);' class='zPushBtn' onclick="AddDisputeApproach();"><img src="/Imgs/Icons/icon018a4.gif" /><b>添加纠纷处理方式&nbsp;</b></a>
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
                                    <td>
                                        <strong>操作</strong>
                                    </td>                                                                      
                                    <td>
                                        <strong>处理方式名称</strong>
                                    </td>                                   
                                </tr>
                                <asp:Repeater runat="server" ID="rpDisputeApproach">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                编辑|删除
                                            </td>                                         
                                            <td>
                                                <%#Eval("ApproachName")%> 
                                            </td>                                           
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>                                
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
