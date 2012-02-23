<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="OMS.Modules.Misc.Reply" %>

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
            name: '取消',
            focus: false,
            callback: function () {
            }
        });

        var i = 0;
        function historyGoBottom() {
            var objDiv = window.document.getElementById("divHistory");
            if (i == 0) {
                objDiv.scrollTop = objDiv.scrollHeight;
                i++;
            }
        }
        var mytimer = setInterval(historyGoBottom, 1);
    </script>
</head>
<body class="dialogBody">
    <form id="form2" runat="server">
    <input type="hidden" runat="server" id="hdStartTime" /> 
    <table width="1024" align="center" cellpadding="2" cellspacing="0">        
        <tr>
            <td width="600" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            纠纷详情</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td align="center" valign="top" width="68%">   
                            <div id="divHistory" style=" width:100%; height:245px; overflow:auto;">    
                            <table width="97%">
                            <asp:Repeater ID="rpHistoryEmail" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="left" valign="middle" class="label" width="15%">
                                        From：</td>
                                    <td align="left" valign="middle" class="content" width="85%"><span <%# Convert.ToBoolean(Eval("IsReply"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%#Eval("Sender")  %></span>———<span <%# Convert.ToBoolean(Eval("IsReply"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%# Eval("CreateTime") %></span></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        Title：</td>
                                    <td align="left" valign="middle" class="content">
                                        <%#Eval("EmailTitle") %>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        Content：</td>
                                  <td align="left" valign="middle" class="label">
                                  <textarea id="taContent" style=" border:none;height:168px; width:100%;" name="taContent" readonly="readonly"><%#Eval("Content") %></textarea>
                                        </td>
                                </tr>
                            </ItemTemplate>
		                    <AlternatingItemTemplate>	
                                <tr>
                                    <td align="left" valign="middle" class="label2">
                                        From：</td>
                                    <td align="left" valign="middle" class="content2">
                                        <span <%# Convert.ToBoolean(Eval("IsReply"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%#Eval("Sender")  %></span>———<span <%# Convert.ToBoolean(Eval("IsReply"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%# Eval("CreateTime") %></span></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label2">
                                        Title：</td>
                                    <td align="left" valign="middle" class="content2">
                                        <%#Eval("EmailTitle") %>    
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label2">
                                        Content：</td>
                                  <td align="left" valign="middle" class="label2">
                                  <textarea id="taContent" style=" border:none;height:168px; width:100%;" name="taContent" readonly="readonly"><%#Eval("Content") %></textarea>
                                        </td>
                                </tr>
                            </AlternatingItemTemplate>
                            </asp:Repeater>					
                            </table>           
                            </div>  
                            <table class="grid">                
						        <tr>
                                    <td align="left" valign="middle" class="label" width="15%">
                                        Reply Title：</td>
                                    <td align="left" valign="middle" class="content" width="85%">
                                        <asp:TextBox ID="txtEmailTitle" runat="server" Width="97%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        Reply Content：</td>
                                    <td align="left" valign="middle" class="content">
                                        <asp:TextBox ID="tbxReply" TextMode="MultiLine" Rows="8" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>                        
                            </table>
                        </td>
                        <td align="left" valign="top" width="32%">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="middle" class="label" colspan="2">
                                        <asp:HyperLink ID="hlinkViewItem" runat="server">ViewItem</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        Our Store：</td>
                                    <td align="left" valign="middle" class="content">
                                        <asp:Label ID="lblOurStore" runat="server" ForeColor="Maroon"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label" width="25%">
                                        MessageType：</td>
                                    <td align="left" valign="middle" class="content" width="75%">
                                        <asp:Label ID="lblMsgType" runat="server"></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        SenderEmail：</td>
                                    <td align="left" valign="middle" class="content">
                                        <asp:Label ID="lblSenderEmail" runat="server"></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        ItemTitle：</td>
                                  <td align="left" valign="middle" class="content">
                                        <asp:Label ID="lblItemTitle" runat="server"></asp:Label></td>
                                </tr>						
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        ItemCurrency：</td>
                                    <td align="left" valign="middle" class="content">
                                        <asp:Label ID="lblItemCurrency" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        ItemValue：</td>
                                    <td align="left" valign="middle" class="content">
                                        <asp:Label ID="lblItemValue" runat="server"></asp:Label>
                                    </td>
                                </tr>              
                            </table>    
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="middle" class="label" colspan="2" style="color:Blue;">
                                        OrderInfo</td>
                                </tr>                      
                                <tr>
                                  <td align="left" valign="top" colspan="2">
                                    <div id="divOrderInfo" style=" width:100%; height:200px; overflow:auto;">    
                            <table width="94%" border="0">
                            <asp:Repeater ID="rpOrderInfo" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="left" valign="middle" class="label" width="15%">
                                        OrderTime：</td>
                                    <td align="left" valign="middle" class="content" width="85%">
                                    <%#Eval("AddOrderTime")%></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        TransactionID：</td>
                                    <td align="left" valign="middle" class="content">
                                        <%#Eval("TxnId")%>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label">
                                        TrackNumber：</td>
                                  <td align="left" valign="middle" class="label">
                                        <%#Eval("TrackCode")%>
                                        </td>
                                </tr>
                            </ItemTemplate>
		                    <AlternatingItemTemplate>	
                                <tr>
                                    <td align="left" valign="middle" class="label2" width="15%">
                                        OrderTime：</td>
                                    <td align="left" valign="middle" class="content2" width="85%">
                                    <%#Eval("AddOrderTime")%></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label2">
                                        TransactionID：</td>
                                    <td align="left" valign="middle" class="content2">
                                        <%#Eval("TxnId")%>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="label2">
                                        TrackNumber：</td>
                                  <td align="left" valign="middle" class="label2">
                                        <%#Eval("TrackCode")%>
                                        </td>
                                </tr>
                            </AlternatingItemTemplate>
                            </asp:Repeater>					
                            </table>           
                            </div> 
                                  </td>
                                </tr>                                     
                            </table>
                        </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnPrefix" runat="server" 
                            Text="发送并转到上一封" onclick="btnPrefix_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="发送并关闭此窗口" onclick="btnSubmit_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSendAndNext" runat="server" Text="发送并转到下一封" onclick="btnSendAndNext_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" Text="转到下一封" onclick="btnNext_Click"/></td></tr>           
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
