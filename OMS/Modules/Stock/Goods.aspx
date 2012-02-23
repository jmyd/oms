<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="OMS.Modules.Stock.Goods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品添加</title>
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var DG = frameElement.lhgDG;
        DG.addBtn('121', "确定", function () {
            document.getElementById('Button3').click();
        }, 'left');

        function ok() {
            DG.cancel();
        }

        function updateParent() {
            DG.curWin.location.reload();
        }

        function showWin(page, id) {
            window.open();
        }
    </script>
    <script type="text/javascript" charset="utf-8" src="/Scripts/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Scripts/kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#txtDesc', {
                cssPath: '/Scripts/kindeditor/plugins/code/prettify.css',
                uploadJson: '/Scripts/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/Scripts/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="800" align="center" cellpadding="2" cellspacing="0">
        <tr>
            <td height="10">
                <asp:Button ID="Button3" Style="display: none;" runat="server" Text="Button" OnClientClick="GetTrans()" />
            </td>
            <td>
                <asp:HiddenField ID="hact" runat="server" />
                <asp:HiddenField ID="hid" runat="server" />
                <asp:HiddenField ID="HItemNo" runat="server" />
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
                            <td height="30" align="right" width="80">
                                商品编号:
                            </td>
                            <td>
                                <input type="text" id="txtItemNo" class="input1 inputText" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                商品名称:
                            </td>
                            <td>
                                <input type="text" id="txtGoodsName" runat="server" class="inputText" onclick="WdatePicker()" /><span
                                    style="color: red; padding-left: 2px; padding-top: 13px;"> *</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                商品类型:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                商品价格:
                            </td>
                            <td>
                                <input type="text" id="txtPrice" class="inputText" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                产品颜色:
                            </td>
                            <td>
                                <input type="text" id="txtColor" class="inputText" runat="server" />
                                <br />
                                多种颜色,请以逗号(,)隔开
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
            <td width="400" valign="top">
                <fieldset>
                    <legend>
                        <label>
                            库存设置</label></legend>
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td height="30" align="right" width="80px">
                                库存数量:
                            </td>
                            <td>
                                <input type="text" id="txtNum" class="input1 inputText" runat="server" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" width="80px">
                                预警上线:
                            </td>
                            <td>
                                <input type="text" id="txtUpper" class="input1 inputText" runat="server" />
                                <br />
                                默认为10000
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                预警下线:
                            </td>
                            <td>
                                <input type="text" id="txtLower" class="input1 inputText" runat="server" />
                                <br />
                                默认为10
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                重量:
                            </td>
                            <td>
                                <input type="text" id="txtWeight" class="input1 inputText" runat="server" />
                                <br />
                                单位为'克'(g)
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="2" style="padding-left: 100px">
                                <a href="javascript:void()" style="cursor: pointer; cursor: hand;">浏览入库记录</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                    href="javascript:showWin('')" style="cursor: pointer; cursor: hand;">浏览出库记录</a>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <textarea id="txtDesc" runat="server" style="width: 100%; height: 300px;"></textarea>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
