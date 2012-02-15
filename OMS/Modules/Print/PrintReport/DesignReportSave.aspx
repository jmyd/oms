<%@ Page Language="C#" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<script runat="server"> 

    // 注意:要成功保存设计的报表模板，ASP.NET系统用户(在IIS 5.x中 <机器名>\ASPNET, 
    // 在 IIS 6.x 中为 NETWORK SERVICE)必须具有模板保存目录的写权限.
    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] FormData = Request.BinaryRead(Request.TotalBytes);

        try
        {
            ////写入上传数据，最后保存到文件
            //string strPathFile = Server.MapPath("~/Modules/Print/PrintReport") + "\\grf\\" + Request.QueryString["Report"] + ".grf";
            //BinaryWriter bw = new BinaryWriter(File.Create(strPathFile));
            //bw.Write(FormData);
            //bw.Close();
        }
        catch (Exception)
        {
        }
        string name = Request.QueryString["Report"];

        OMS.Core.DoMain.PrintTemplateType ptt = OMS.Core.DoMain.PrintTemplateType.find("Name='" + name + "'").first();
        if (ptt == null)
        {
            ptt = new OMS.Core.DoMain.PrintTemplateType();
            ptt.Name = name;
            ptt.Content = System.Text.Encoding.UTF8.GetString(FormData);
            ptt.insert();

        }
        else
        {
            ptt.Content = System.Text.Encoding.UTF8.GetString(FormData);
            ptt.update();
        }

    }
</script>
