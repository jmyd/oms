using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO.Compression;
using System.Data;

namespace OMS
{
    public class Utilities
    {
        /// <summary>
        /// 获得
        /// </summary>
        /// <param name="dt"></param>
        public static string GetIds(DataTable dt)
        {
            string Ids = "";
            foreach (DataRow dr in dt.Rows)
            {
                Ids += dr["Id"] + ",";
            }
            return Ids.Trim(',');
        }

        /// <summary>
        /// 注册页面js
        /// </summary>
        /// <param name="message">js</param>
        public static void ShowJS(string js)
        {
            // message = StringUtil.DeleteUnVisibleChar(message);
            js = @"<script language='JavaScript'>
                   " + js + "</script>";

            //2008年4月26日15:46:38 Modify by zxy
            //现在使用Page来注册脚本，如果使用 Response.Write来输出脚本，该脚本会出现在页面的顶部，破坏页面的布局。
            Page page = System.Web.HttpContext.Current.Handler as Page;
            if (page != null)
            {
                string key = "Alert" + Guid.NewGuid();
                if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                    page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
            }
            else
                HttpContext.Current.Response.Write(js);
        }

        public static string GetPrintPath(string fileName, string Data)
        {
            string path = "/Modules/Print/PrintReport/PrintReport.aspx";
            path += "?Report=" + fileName;

            path += "&Data=/Modules/Print/Data/" + Data;
            return path;
        }

        public static void ResponseXml(System.Web.UI.Page DataPage, ref string XMLText, bool ToCompress)
        {
            //报表XML数据的前后不能附加任何其它数据，否则XML数据将不能成功解析，所以调用ClearContent方法清理网页中前面多余的数据
            DataPage.Response.ClearContent();

            if (ToCompress)
            {
                //将string数据转换为byte[]，以便进行压缩
                //System.Text.UnicodeEncoding converter = new System.Text.UnicodeEncoding();
                System.Text.UTF8Encoding converter = new System.Text.UTF8Encoding();
                byte[] XmlBytes = converter.GetBytes(XMLText);

                //在 HTTP 头信息中写入报表数据压缩信息
                DataPage.Response.AppendHeader("gr_zip_type", "deflate");                  //指定压缩方法
                DataPage.Response.AppendHeader("gr_zip_size", XmlBytes.Length.ToString()); //指定数据的原始长度
                DataPage.Response.AppendHeader("gr_zip_encode", converter.HeaderName);     //指定数据的编码方式 utf-8 utf-16 ...

                // 把压缩后的xml数据发送给客户端
                DeflateStream compressedzipStream = new DeflateStream(DataPage.Response.OutputStream, CompressionMode.Compress, true);
                compressedzipStream.Write(XmlBytes, 0, XmlBytes.Length);
                compressedzipStream.Close();
            }
            else
            {
                // 把xml对象发送给客户端
                //DataPage.Response.ContentType = "text/xml";
                DataPage.Response.Write(XMLText);
            }

            //报表XML数据的前后不能附加任何其它数据，否则XML数据将不能成功解析，所以调用End方法放弃网页中后面不必要的数据
            DataPage.Response.End();
        }
    }
}