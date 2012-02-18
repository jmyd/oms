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
                    this.reload();
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
            <td width="500" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            纠纷详情</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" style=" display:none;" runat="server" Text="Button" 
                                    onclick="btnSubmit_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                订单编号:
                            </td>
                            <td>
                                <input type="text" id="txtOrderExNo" runat="server" /> <asp:Button 
                                    ID="btnSearch" Text="查 找" runat="server" onclick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                平台:
                            </td>
                            <td>
                                <input type="text" id="txtPlatformName" runat="server" />
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                账户:
                            </td>
                            <td>
                                <input type="text" id="txtSaleAccountName" runat="server" />
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                发货时间:
                            </td>
                            <td>
                                <input type="text" id="txtSendOrderDate" runat="server" />
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                产品编号:
                            </td>
                            <td>
                                <input type="text" id="txtItemNo" runat="server" />
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                跟踪码:
                            </td>
                            <td>
                                <input type="text" id="txtTrackCode" runat="server" />
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                运输方式:
                            </td>
                            <td>
                                <input type="text" id="txtTransportMode" runat="server" />
                            </td>
                        </tr>  
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
                                纠纷状态:
                            </td>
                            <td>
                                <input name="state" type="radio" value="未解决" id="state0" checked="checked" /><label for="state0">未解决</label>&nbsp;&nbsp;
                                <input name="state" type="radio" value="已解决" id="state1" /><label for="state1">已解决</label>
                            </td>
                        </tr>  
                        <tr>
                            <td height="30" align="right">
                                解决日期:
                            </td>
                            <td>
                                <input type="text" id="txtApproachOn" runat="server" class="inputText" onclick="WdatePicker()" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                解决方式:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDisputeApproach" runat="server"></asp:DropDownList>
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
                        <tr>
                            <td height="30" align="right">
                                备注:
                            </td>
                            <td>
                                <textarea id="txtRemark" runat="server"></textarea>
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
