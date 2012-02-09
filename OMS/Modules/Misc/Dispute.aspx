<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dispute.aspx.cs" Inherits="OMS.Modules.Misc.Dispute" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <asp:Literal ID="ltTitle" runat="server"></asp:Literal></title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        var api = frameElement.api;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
                document.getElementById('btnSubmit').click();
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
                <asp:Button ID="btnSubmit" runat="server" Style="display: none;" Text="Button" 
                    onclick="btnSubmit_Click"/>
                <asp:HiddenField ID="hid" runat="server" />
                <asp:HiddenField ID="hact" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="500" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            纠纷详情</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="39%" height="30" align="right">
                                纠纷日期:
                            </td>
                            <td width="61%">
                                <input type="text" id="txtCreateOn" runat="server" class="inputText" onclick="WdatePicker()" /><span
                            style="color: red; padding-left: 2px; padding-top: 13px;">*</span>
                            </td>
                        </tr>                        
                        <tr>
                            <td height="30" align="right">
                                纠纷分类:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDisputeCategory" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                纠纷类型:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDisputeType" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                订单编号:
                            </td>
                            <td>
                                <input type="text" id="txtOrderCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                解决日期:
                            </td>
                            <td>
                                <input type="text" id="txtFinishOn" runat="server" class="inputText" onclick="WdatePicker()" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                解决方式:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSolutionType" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                退款金额:
                            </td>
                            <td>
                                <input type="text" id="txtRefundAmount" runat="server" /> <asp:DropDownList ID="ddlCurrencyType" runat="server"></asp:DropDownList>
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
