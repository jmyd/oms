using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;

namespace OMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void LoginImg_Click(object sender, ImageClickEventArgs e)
        {
            UserType ut = UserType.find("CompanyCode=:t1 and UserName =:t2 and UserPassword =:t3").set("t1", txtCCode.Value.Trim()).set("t2", txtUserName.Value.Trim()).set("t3", txtUserPassWord.Value.Trim()).first();
            if (ut != null)
            {
                Session["CompanyCode"] = ut.CompanyCode;
                Response.Redirect("default.aspx");
            }

        }
    }
}