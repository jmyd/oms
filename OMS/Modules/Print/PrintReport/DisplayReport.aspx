<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>展现报表</title>
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
</head>
<body style="margin: 0; overflow: hidden" scroll="no">

    <script language="javascript"> 
    
	    var Report = "<%=Request.QueryString["Report"]%>";
	    if (Report != "")
	      
            Report = "ReadReport.aspx?Report="+Report;//"grf/" + Report;
	    CreateDisplayViewer(Report, "<%=Request.QueryString["Data"]%>") 
    </script>

</body>
</html>
