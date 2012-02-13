<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ReportAndData", "window.report='" + Page.Request.QueryString["Report"] + "';window.data='" + Page.Request.QueryString["Data"] + "&Design=true';", true);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设计报表 -
        <%=Request.QueryString["Report"]%></title>
    <!--Grid_Report-->
    <script src="/Scripts/GRUtility.js" type="text/javascript"></script>
    <script src="/Scripts/CreateControl.js" type="text/javascript"></script>
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }
    </style>
</head>
<body style="margin: 0; overflow: hidden" scroll="no">
    <form id="form1" runat="server">
    <script language="JavaScript" for="ReportDesigner" event="SaveReport()">
<!--
	//alert("为了保护报表的正常演示，这里放弃了对报表设计的保存！");
	//ReportDesigner.DefaultAction = false;
-->
    </script>
    <script language="javascript">
        var Report = window.report;
        if (Report != "")
        //Report = "grf/" + Report;
            Report = "ReadReport.aspx?Report=" + Report; //"grf/" + Report;
        CreateDesigner(Report, "DesignReportSave.aspx?Report=" + window.report, window.data);
    </script>
    </form>
</body>
</html>
