<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OMS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FOMS 订单管理系统 登录</title>
    <link href="css/Default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .input1
        {
            border: 1px solid #84A1BD;
            width: 100px;
            height: 20px;
            line-height: 23px;
        }
        .input2
        {
            border: 1px solid #84A1BD;
            width: 68px;
            height: 20px;
            line-height: 23px;
        }
        .button1
        {
            border: none;
            width: 70px;
            height: 27px;
            line-height: 23px;
            color: #525252;
            font-size: 12px;
            font-weight: bold;
            background-image: url(/Imgs/img/bt001.jpg);
            background-repeat: no-repeat;
            background-position: 0px 0px;
        }
        .button2
        {
            border: none;
            width: 70px;
            height: 27px;
            line-height: 23px;
            color: #525252;
            font-size: 12px;
            font-weight: bold;
            background-image: url(/Imgs/img/bt002.jpg);
            background-repeat: no-repeat;
            background-position: 0px 0px;
        }
        .STYLE3
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" style="display: block; height: 100%;" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td align="center" valign="middle">
                <table style="height: 283px; width: 620px; background: url(/Imgs/img/loginbg.jpg) no-repeat 0px 0px;">
                    <tr>
                        <td>
                            <div style="height: 213px; width: 620px;">
                            </div>
                            <div style="height: 70px; width: 620px; margin: 0px auto 0px auto;">
                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 8px;">
                                    <tr>
                                        <td align="center">
                                            公司：<input name="UserName" type="text" style="width: 120px" id="txtCCode" class="inputText"
                                                onfocus="this.select();" runat="server" />
                                            &nbsp;用户名：
                                            <input name="UserName" type="text" style="width: 120px" id="txtUserName" class="inputText"
                                                onfocus="this.select();" runat="server" />
                                            &nbsp;密码：
                                            <input name="Password" type="password" style="width: 120px" id="txtUserPassWord"
                                                class="inputText" onfocus="this.select();" runat="server" />
                                            &nbsp;
                                            <asp:ImageButton runat="server" ID="LoginImg" ImageUrl="/Imgs/img/loginbutton.jpg"
                                                tyle="cursor: pointer" align="absmiddle" OnClick="LoginImg_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="23" align="center" valign="bottom">
                                            Copyright &copy; 2006-2011 Inc. All rights reserved. 飞度软件 版权所有
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
