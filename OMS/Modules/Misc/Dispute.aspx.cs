using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Core.DoMain;
using wojilu;
using wojilu.Data;
using wojilu.ORM;
using System.Collections;

namespace OMS.Modules.Misc
{
    public partial class Dispute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DisputeType di = new DisputeType();
            DateTime createTime = new DateTime();
            string strCreateDate = Request.Form[txtCreateOn.ID].Trim();
            if (string.IsNullOrEmpty(strCreateDate) || !DateTime.TryParse(strCreateDate, out createTime))
            {
                return;
            }
            di.CreateOn = createTime;
            di.insert();


        }
    }
}