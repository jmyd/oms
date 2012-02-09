<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrderByAPI.aspx.cs"
    Inherits="OMS.Modules.Order.AddOrderByAPI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>同步订单</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        var api = frameElement.api;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
                document.getElementById('Button1').click();
            }
        });
        api.button({
            name: '取消',
            focus: false,
            callback: function () {

            }
        });
    </script>
</head>
<body class="dialogBody">
    <form id="form2" runat="server">
    <table width="400" align="center" cellpadding="2" cellspacing="0">
        <tr>
            <td height="10">
                <!--Style="display: none;"-->
                <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Button" OnClick="Button1_Click" />
                <asp:HiddenField ID="hid" runat="server" />
                <asp:HiddenField ID="hact" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="400" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            基本信息</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="39%" height="30" align="right">
                                开始时间:
                            </td>
                            <td width="61%">
                                <input type="text" id="txtBegin" runat="server" readonly="readonly" /><img onclick="WdatePicker({el:'txtBegin'})"
                                    src="/Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                结束时间:
                            </td>
                            <td>
                                <input type="text" id="txtEnd" runat="server" readonly="readonly" /><img onclick="WdatePicker({el:'txtEnd'})"
                                    src="/Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
