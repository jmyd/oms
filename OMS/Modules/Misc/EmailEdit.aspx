<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailEdit.aspx.cs" Inherits="OMS.Modules.Misc.EmailEdit" %>

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
    <style type="text/css">
    .lable_style{background-color:#CCCCCC;}
    .content_style{background-color:#E2E2E2;} 
    .lable_style2{background-color:#B5CBD0;}
    .content_style2{background-color:#E2EBED;}    
    </style>
</head>
<body class="dialogBody">
    <form id="form2" runat="server">
    <table width="990" align="center" cellpadding="2" cellspacing="0">        
        <tr>
            <td width="990" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            邮件详情</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top" width="70%">
                                <table width="100%" cellspacing="2">
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style" width="15%">
                                            From：</td>
                                        <td align="left" valign="middle" class="content_style" width="85%">
                                            <asp:Label ID="lblFrom" runat="server" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style2">
                                            Subject：</td>
                                        <td align="left" valign="middle" class="content_style2">
                                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                      </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            Content：</td>
                                      <td align="left" valign="middle" class="content_style">
                                            <asp:TextBox ID="tbxContent" ReadOnly="true" TextMode="MultiLine" style=" border:none;height:128px; width:99%;" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                    </tr>
						            <tr>
                                        <td align="left" valign="middle" class="lable_style2">
                                            Reply Subject：</td>
                                        <td align="left" valign="middle" class="content_style2">
                                            <asp:TextBox ID="txtEmailTitle" runat="server" Width="525"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            Reply Content：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:TextBox ID="tbxReply" TextMode="MultiLine" style=" border:none;height:128px; width:99%;" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                    </tr>                        
                                </table>
                            </td>
                            <td align="left" valign="top" width="30%">
                                <table width="100%" cellspacing="2">
                                    <tr>
                                        <td align="center" valign="middle" class="lable_style" colspan="2">
                                            <asp:HyperLink ID="hlinkViewItem" runat="server">ViewItem</asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            Our Store：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblOurStore" runat="server" ForeColor="Maroon"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style" width="20%">
                                            MessageType：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblMsgType" runat="server"></asp:Label>
                                      </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            SenderEmail：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblSenderEmail" runat="server"></asp:Label>
                                      </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            ItemTitle：</td>
                                      <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblItemTitle" runat="server"></asp:Label></td>
                                    </tr>	
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            ItemPrice：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblItemValue" runat="server"></asp:Label>
                                        </td>
                                    </tr> 					
                                    <tr>
                                        <td align="left" valign="middle" class="lable_style">
                                            ItemCurrency：</td>
                                        <td align="left" valign="middle" class="content_style">
                                            <asp:Label ID="lblItemCurrency" runat="server"></asp:Label>
                                        </td>
                                    </tr>                                                       
                                </table>
                            </td>
                        </tr>
                        <tr><td colspan="2" align="center">
                            <asp:Button ID="btnSubmit" style=" display:none" runat="server" Text="提 交" onclick="btnSubmit_Click" /></td></tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

