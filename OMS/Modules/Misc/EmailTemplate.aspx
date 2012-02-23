<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplate.aspx.cs" Inherits="OMS.Modules.Misc.EmailTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/kindeditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="../../Scripts/kindeditor/kindeditor.js" type="text/javascript"></script>
        <script type="text/javascript">
            KindEditor.ready(function (K) {
                var editor1 = K.create('#txtDesc', {
                    cssPath: '/static/js/kindeditor/plugins/code/prettify.css',
                    uploadJson: '/static/js/kindeditor/asp.net/upload_json.ashx',
                    fileManagerJson: '/static/js/kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true
                });

            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="252px" 
            Width="394px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
