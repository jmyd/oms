<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.UI.Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ReportAndData", "window.report='" + Page.Request.QueryString["Report"] + "';window.data='" + Page.Request.QueryString["Data"] + "';", true);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印预览</title>
    <!--Grid_Report-->
    <script src="/Scripts/GRUtility.js" type="text/javascript"></script>
    <script src="/Scripts/CreateControl.js" type="text/javascript"></script>
    <style type="text/css">
        html, body, form
        {
            margin: 0;
            height: 100%;
        }
    </style>
    <style type="text/css">
        html, body, form
        {
            margin: 0;
            height: 100%;
        }
    </style>
</head>
<body style="margin: 0; overflow: hidden" scroll="no" onload="window_onload()">
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">
        //改变工具栏按钮
        function window_onload() {
            //隐藏插件工具栏上的部分按钮与菜单项。首先用RemoveToolbarControl方法指定要隐藏的项
            //最后用UpdateToolbar方法更新显示。RemoveToolbarControl中的参数指定要隐藏的按钮与
            //菜单项，对应的常数值请查帮助中枚举 GRToolControlType 的定义。
            ReportViewer = document.getElementById("ReportViewer");

            //隐藏导出按钮
            //ReportViewer.RemoveToolbarControl(5);
            //隐藏导出并发送邮件按钮
            ReportViewer.RemoveToolbarControl(6);
            //隐藏保存打印文档按钮
            ReportViewer.RemoveToolbarControl(7);
            //隐藏导出 Excel 菜单
            ReportViewer.RemoveToolbarControl(50);
            //隐藏导出文本菜单项
            ReportViewer.RemoveToolbarControl(51);
            //隐藏导出 HTML 菜单项
            //ReportViewer.RemoveToolbarControl(52);
            //隐藏导出 RTF 菜单项
            ReportViewer.RemoveToolbarControl(53);
            //隐藏导出 PDF 菜单项
            //ReportViewer.RemoveToolbarControl(54);
            //隐藏导出 CSV 菜单项
            ReportViewer.RemoveToolbarControl(55);
            //隐藏导出图像菜单项
            //ReportViewer.RemoveToolbarControl(56);
            //            //隐藏导出HTM菜单项
            //            ReportViewer.RemoveToolbarControl(57);
            //            //隐藏导出HTM菜单项
            //            ReportViewer.RemoveToolbarControl(58);
            //            //隐藏导出HTM菜单项
            //            ReportViewer.RemoveToolbarControl(59);
            //隐藏导出 Excel 按钮
            ReportViewer.RemoveToolbarControl(60);
            //隐藏导出 PDF 按钮
            ReportViewer.RemoveToolbarControl(61);

            //加一个自定义按钮: 首先加一个分隔栏; 然后加自定义按钮,参数1为按钮标识号,第二个为按钮
            //图像文件(必须为16*16,256色的bmp位图，背景为纯黑色), 第三个参数为按钮提示文字。
            //按钮点击后触发CustomButtonClick事件
            ReportViewer.AddToolbarControl(1);
            ReportViewer.AddToolbarCustomButton(1, "images/Design.gif", "设计");
            ReportViewer.AddToolbarCustomButton(2, "images/Display.gif", "展现报表");
            ReportViewer.AddToolbarCustomButton(3, "images/data.gif", "数据");

            //最后更新显示
            ReportViewer.UpdateToolbar();
        }


        //debugger;
        var Report = window.report;

        if (Report != "")
            Report = "ReadReport.aspx?Report=" + Report; //"grf/" + report;


        CreatePrintViewer(Report, window.data)
       
      
    </script>
    <script language="JavaScript" for="ReportViewer" event="CustomButtonClick(BtnID)"> 
  
            if(BtnID==1){
             location="DesignReport.aspx?Report="+window.report+"&Data="+window.data+"";
             //alert("DesignReport.aspx?Report="+window.report+"&Data="+window.data+"");
            }
            if(BtnID==2){
             location="DisplayReport.aspx?Report="+window.report+"&Data="+window.data+"";
             //alert("DisplayReport.aspx?Report="+window.report+"&Data="+window.data+"");
            }
            if(BtnID==3){
             location=window.data;
             //alert("DesignReport.aspx?Report="+window.report+"&Data="+window.data+"");
            }
    </script>
    </form>
</body>
</html>
