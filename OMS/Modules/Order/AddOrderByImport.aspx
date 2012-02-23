<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrderByImport.aspx.cs"
    Inherits="OMS.Modules.Order.AddOrderByImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <asp:Literal ID="ltTitle" runat="server"></asp:Literal></title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
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
    <table width="500" align="center" cellpadding="2" cellspacing="0">
        <tr>
            <td height="10">
                <asp:Button ID="Button1" runat="server" Style="display: none;" Text="Button" OnClick="Button1_Click" />
                <asp:HiddenField ID="hid" runat="server" />
                <asp:HiddenField ID="hact" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="500" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            导入选项</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="39%" height="30" align="right">
                                平台:
                            </td>
                            <td width="61%">
                                <input type="text" id="txtCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                账号:
                            </td>
                            <td>
                                <input type="text" id="txtFullName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                导入文件:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
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
