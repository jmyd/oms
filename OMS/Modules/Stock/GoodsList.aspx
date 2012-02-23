<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="OMS.Modules.Stock.GoodsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品列表</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/lhgdialog/lhgdialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AddCompany() {
            $.dialog({ content: 'url:Company.aspx' });
        }

        function CheckDB(code) {
            $.dialog({ content: 'url:CheckDB.aspx?code=' + code

            });
        }

        function AddDB(code) {
            $.dialog({ content: "" })
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellspacing="6" cellpadding="0" border="0" style="border-collapse: separate;
        border-spacing: 6px;">
        <tbody>
            <tr valign="top">
                <td>
                    <table width="100%" cellspacing="0" cellpadding="6" border="0" class="blockTable">
                        <tbody>
                            <tr>
                                <td valign="middle" class="blockTd">
                                    <img src="/imgs/Icons/icon026a1.gif" />
                                    商品管理
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0 8px 4px;">
                                    <a onclick="add(this);return false;" id="" onselectstart="return false" tabindex="-1"
                                        hidefocus="true" class="zPushBtn" href="javascript:void(0);">
                                        <img src="/imgs/Icons/icon026a2.gif"><b>新建&nbsp;</b></a>
                                    <asp:LinkButton ID="lbDel" runat="server" hidefocus="true" onselectstart="return false"
                                        TabIndex="-1" class="zPushBtn" OnClick="lbDel_Click" OnClientClick="return vali();">  <img src="/imgs/Icons/icon026a3.gif"><b>删除&nbsp;</b></asp:LinkButton>
                                    <a onclick="cate();return false;" id="A1" onselectstart="return false" tabindex="-1"
                                        hidefocus="true" class="zPushBtn" href="javascript:void(0);">
                                        <img src="/imgs/Icons/icon026a4.gif"><b>分类&nbsp;</b></a>
                                    <div style="float: right; white-space: nowrap;">
                                        <input type="text" style="width: 150px;" value="" id="txtSearch" name="txtSearch"
                                            class="inputText" runat="server" />
                                        <asp:Button runat="server" ID="Submitbutton" Text="查询" OnClick="Submitbutton_Click" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 0px; padding-left: 6px; padding-right: 6px; padding-bottom: 8px;">
                                    <table width="100%" cellspacing="0" cellpadding="2" id="dg1" class="dataTable">
                                        <thead>
                                            <tr class="dataTableHead" ztype="head">
                                                <td width="5%" ztype="selector">
                                                    <input type="checkbox" id="chkAll" class="inputCheckbox" />
                                                </td>
                                                <td width="10%">
                                                    <b>操作</b>
                                                </td>
                                                <td width="10%">
                                                    <b>商品编号</b>
                                                </td>
                                                <td width="10%">
                                                    <b>商品名称</b>
                                                </td>
                                                <td width="10%">
                                                    <b>商品类型</b>
                                                </td>
                                                <td width="18%">
                                                    <b>商品价格</b>
                                                </td>
                                                <td width="42%">
                                                    <b>描述</b>
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpGoods" runat="server">
                                                <ItemTemplate>
                                                    <tr style="background-color: #F9FBFC">
                                                        <td>
                                                            <input type="checkbox" name="chkItem" code='<%# Eval("id") %>' class="inputCheckbox" />
                                                        </td>
                                                        <td>
                                                            <a href="javascript:edit(this,<%# Eval("Id") %>);">编辑</a> | <a href="javascript:setup(<%# Eval("Id") %>);">
                                                                对应系数</a>
                                                        </td>
                                                        <td title="<%#Eval("ItemNo") %>">
                                                            <%#Eval("ItemNo") %>
                                                        </td>
                                                        <td title="<%#Eval("ItemName") %>">
                                                            <%#Eval("ItemName")%>
                                                        </td>
                                                        <td title="<%#Eval("ItemType") %>">
                                                            <%#Eval("ItemType")%>
                                                        </td>
                                                        <td title="<%#Eval("ItemPrice") %>">
                                                            <%#Eval("ItemPrice")%>
                                                        </td>
                                                        <td title="<%#Eval("Description") %>">
                                                            <%#Eval("Description")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td align="center" id="dg1_PageBar" colspan="5">
                                                    <div style='float: right; font-family: Tahoma'>
                                                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" firstpagetext="第一页" lastpagetext="最末页"
                                                            nextpagetext="下一页" pagingbuttonlayouttype="None" prevpagetext="上一页" onpagechanged="AspNetPager1_PageChanged">
                                                        </webdiyer:aspnetpager>
                                                    </div>
                                                    <div style='float: left; font-family: Tahoma'>
                                                        &nbsp;</div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        //全选/反选
        $("#chkAll").click(function () {
            $('#dg1 > tbody > tr > td > input:checkbox').attr("checked", this.checked);
        });

        //若所有tbody中的项都选中了,自动将表头中的chkAll选中.
        $("#dg1 > tbody > tr > td > input:checkbox").click(function () {
            //获取所有选中的checkbox元素
            var expression1 = $("#dg1 > tbody > tr > td > input:checkbox:checked");
            //获取所有checkbox元素
            var expression2 = $("#dg1 > tbody > tr > td > input:checkbox");
            var hasChecked = $(expression1).length == $(expression2).length;
            $("#chkAll").attr("checked", hasChecked);
        });

        //获取表格中选中的值
        function vali() {
            var selectedCodes = new Array();
            var checkedItems = $("#dg1 > tbody > tr > td > input:checkbox:checked[@name$='chkItem']");
            $.each(checkedItems, function () {
                selectedCodes.push($(this).attr("code"));
            });
            if (0 == selectedCodes.length) {
                alert("没有选中任何项..");
                return false;
            }
            if (confirm("确认删除吗")) {

                $("#hids").val(selectedCodes.join(","));
                return true;
            } else {
                return false;
            }

        }
       

    </script>
    <asp:HiddenField ID="hids" runat="server" />
    <asp:HiddenField ID="hkey" runat="server" />
    </form>
</body>
</body>
</html>
