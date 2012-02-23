using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Core.DoMain;
using wojilu;

namespace OMS.Modules.Misc
{
    public partial class DisputeCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Session["CompanyCode"] = "OMSTest";

                rpDisputeCategory.DataSource = DisputeCategoryType.findAll();
                rpDisputeCategory.DataBind();
            }
        }
    }
}