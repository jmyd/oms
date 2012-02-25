<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisputeList.aspx.cs" Inherits="OMS.Modules.Misc.DisputeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer"  TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>纠纷列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AddDispute() {
            $.dialog({ title:'纠纷', content: 'url:Dispute.aspx'
            });
        } 

        function EditDispute(id) {
            $.dialog({ title:'纠纷', content: 'url:Dispute.aspx?id=' + id
            });
        } 
        function DelDispute(id) {
            $.dialog.confirm('你确定要删除这条消息吗？', function(){
                document.getElementById("hId").value=id;
                document.getElementById("btnSubmit").click();
                this.reload();
            }, function(){
                $.dialog.tips('您已经取消操作！');
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
                            <img src="/Imgs/Icons/icon018a1.gif" />纠纷列表
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 8px 4px;">
                            <a href='javascript:void(0);' class='zPushBtn' onclick="AddDispute();"><img src="/Imgs/Icons/icon018a4.gif" /><b>添加纠纷&nbsp;</b></a>
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
                                        <strong>纠纷日期</strong>
                                    </td>
                                    <td>
                                        <strong>纠纷类型</strong>
                                    </td>
                                    <td>
                                        <strong>订单号</strong>
                                    </td>
                                    <td>
                                        <strong>产品编号</strong>
                                    </td>
                                    <td>
                                        <strong>跟踪号码</strong>
                                    </td>
                                    <td>
                                        <strong>发货日期</strong>
                                    </td>
                                    <td>
                                        <strong>状态</strong>
                                    </td>
                                    <td>
                                        <strong>解决日期</strong>
                                    </td>
                                    <td>
                                        <strong>结果</strong>
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rpDispute">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <a href="javascript:EditDispute(<%# Eval("Id") %>);">编辑</a> | <a href="javascript:DelDispute(<%# Eval("Id") %>);">
                                                                删除</a>
                                            </td>
                                            <td>
                                                <%#Eval("CreateOn")%>
                                            </td>
                                            <td>
                                                <%#Eval("DisputeCategory")%> <%#Eval("DisputeTypeCode")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderNo")%>
                                            </td>
                                            <td>
                                                <%#Eval("ItemNo")%>
                                            </td>
                                            <td>
                                                <%#Eval("TrackCode")%>
                                            </td>
                                            <td>
                                                <%#Eval("SendOrderDate")%>
                                            </td>
                                            <td>
                                                <%#Eval("DisputeStatus")%>
                                            </td>
                                            <td>
                                                <%#Eval("ResolutionTime")%>
                                            </td>
                                            <td>
                                                <%#Eval("DisputeSolutionType")%> <%#Eval("DisputeSolutionType")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="9" align="left" id="dg1_PageBar">
                                        <div style='float: right; font-family: Tahoma'>
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb"
                                                FirstPageText="第一页" LastPageText="最末页" NextPageText="下一页" PagingButtonLayoutType="None"
                                                PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
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
        <tr>
            <td><asp:Button ID="btnSubmit" style=" display:none;" runat="server" Text="Button" 
                    onclick="btnSubmit_Click"/>
                <asp:HiddenField ID="hId" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

