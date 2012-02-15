<%@ Page Language="C#" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<script runat="server"> 

    protected void Page_Load(object sender, EventArgs e)
    {
        //不保留缓存
        Response.Buffer = true;
        Response.Expires = 0;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.CacheControl = "no-cache";
        //将报表模板文件数据发送给请求者。供报表插件读取模板数据

        string strPathFile = Server.MapPath("~/Modules/Print/PrintReport") + "\\grf\\" + Request.QueryString["Report"] + ".grf";
        Response.WriteFile(strPathFile);

        //OMS.Core.DoMain.PrintTemplateType ptt = OMS.Core.DoMain.PrintTemplateType.findById(wojilu.cvt.ToInt(Request.QueryString["Report"]));
        //if (ptt != null)
        //{
        //    Response.Write(ptt.Content);
        //}
        //else
        //{
        //    throw new Exception("读取报表文件失败，没有找到编号为 " + Request.QueryString["Report"] + " 的报表");
        //}
    }
</script>
