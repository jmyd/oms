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
            name: '转到下一封',
            focus: true,
            callback: function () {
                document.getElementById('btnNext').click();
                return true;
            }
        });
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
    <style type="text/css">
    .lable_style{background-color:#CCCCCC;}
    .content_style{background-color:#E2E2E2;} 
    .lable_style2{background-color:#B5CBD0;}
    .content_style2{background-color:#E2EBED;}    
    </style>
</head>
<body class="dialogBody">
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hdStartTime" /> 
    <table align="center" cellpadding="2" cellspacing="0" width="990">        
        <tr>
            <td width="990" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            邮件详情</label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td align="center" valign="top" width="663">   
                            <div id="divHistory" style=" width:100%; height:230px; overflow:auto;">    
                            <table width="645" cellspacing="2">
                            <asp:Repeater ID="rpHistoryEmail" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="left" valign="middle" width="15%" class="lable_style">
                                        From：</td>
                                    <td align="left" valign="middle" width="85%" class="content_style"><span <%# Convert.ToBoolean(Eval("IsToEbay"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%#Eval("Replier")  %></span>———<span <%# Convert.ToBoolean(Eval("IsToEbay"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%# Eval("CreateOn") %></span></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style">
                                        Subject：</td>
                                    <td align="left" valign="middle" class="content_style">
                                        <%#Eval("Subject")%>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style">
                                        Content：</td>
                                  <td align="left" valign="middle" class="content_style">
                                  <textarea id="taContent" style=" border:none;height:158px; width:99%;" name="taContent" readonly="readonly"><%#Eval("Body") %></textarea>
                                        </td>
                                </tr>
                            </ItemTemplate>
		                    <AlternatingItemTemplate>	
                                <tr>
                                    <td align="left" valign="middle" class="lable_style2">
                                        From：</td>
                                    <td align="left" valign="middle" class="content_style2">
                                        <span <%# Convert.ToBoolean(Eval("IsToEbay"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%#Eval("Replier")  %></span>———<span <%# Convert.ToBoolean(Eval("IsToEbay"))?"style='color:Maroon;'":"style='color:Blue;'" %>><%# Eval("CreateOn") %></span></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style2">
                                        Subject：</td>
                                    <td align="left" valign="middle" class="content_style2">
                                        <%#Eval("Subject")%>    
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style2">
                                        Content：</td>
                                  <td align="left" valign="middle" class="content_style2">
                                  <textarea id="taContent" style=" border:none;height:158px; width:99%;" name="taContent" readonly="readonly"><%#Eval("Body") %></textarea>
                                        </td>
                                </tr>
                            </AlternatingItemTemplate>
                            </asp:Repeater>					
                            </table>           
                            </div>  
                            <table width="100%" cellspacing="2">                
						        <tr>
                                    <td align="left" valign="middle" width="15%" class="lable_style">
                                        Reply Subject：</td>
                                    <td align="left" valign="middle" width="85%" class="content_style">
                                        <asp:TextBox ID="txtEmailTitle" runat="server" Width="549"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style">
                                        Reply Content：</td>
                                    <td align="left" valign="middle" class="content_style">
                                        <asp:TextBox ID="tbxReply" TextMode="MultiLine" style=" border:none;height:128px; width:99%;" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>                        
                            </table>
                        </td>
                        <td align="left" valign="top" width="310">
                            <table width="310" cellspacing="2">
                                <tr>
                                    <td align="center" valign="middle" colspan="2" class="lable_style">
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
                                    <td align="left" valign="middle" width="25%" class="lable_style">
                                        MessageType：</td>
                                    <td align="left" valign="middle" width="75%" class="content_style">
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
                            <table width="310" cellspacing="2">
                                <tr>
                                    <td align="center" valign="middle" colspan="2" style="color:Blue;" class="lable_style">
                                        OrderInfo</td>
                                </tr>                      
                                <tr>
                                  <td align="left" valign="top" colspan="2">
                                    <div id="divOrderInfo" style=" width:100%; height:200px; overflow:auto;">    
                            <table width="304" border="0">
                            <asp:Repeater ID="rpOrderInfo" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="left" valign="middle" width="15%" class="lable_style">
                                        OrderTime：</td>
                                    <td align="left" valign="middle" width="85%" class="content_style">
                                    <%#Eval("AddOrderTime")%></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style">
                                        TransactionID：</td>
                                    <td align="left" valign="middle" class="content_style">
                                        <%#Eval("TxnId")%>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style">
                                        TrackNumber：</td>
                                  <td align="left" valign="middle" class="content_style">
                                        <%#Eval("TrackCode")%>
                                        </td>
                                </tr>
                            </ItemTemplate>
		                    <AlternatingItemTemplate>	
                                <tr>
                                    <td align="left" valign="middle" width="15%" class="lable_style2">
                                        OrderTime：</td>
                                    <td align="left" valign="middle" width="85%" class="content_style2">
                                    <%#Eval("AddOrderTime")%></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style2">
                                        TransactionID：</td>
                                    <td align="left" valign="middle" class="content_style2">
                                        <%#Eval("TxnId")%>
                                  </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" class="lable_style2">
                                        TrackNumber：</td>
                                  <td align="left" valign="middle" class="content_style2">
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
