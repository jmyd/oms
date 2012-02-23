using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using wojilu;

namespace OMS
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {

            return "Hello World";
        }
    }
}
