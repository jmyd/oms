using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;

namespace OMS.Modules.User
{
    public partial class CompanyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                rpOrder.DataSource = CompanyType.findAll();
                rpOrder.DataBind();
            }
        }
    }
}