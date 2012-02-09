using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;

namespace OMS.Modules.Misc
{
    public partial class DisputeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                rpDispute.DataSource = DisputeType.findAll();
                rpDispute.DataBind();
            }
        }
    }
}