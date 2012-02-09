using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Modules.Order
{
    public partial class AddOrderByAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtEnd.Value = DateTime.Now.ToShortDateString();
                txtBegin.Value = DateTime.Now.AddDays(-3).ToShortDateString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["CompanyCode"] = "OMSTest";
            OMS.Tools.EbayOrderUtil eot = new Tools.EbayOrderUtil();

            eot.GetOrderByAPI(OMS.Core.DoMain.SaleAccountType.find("").first(), Convert.ToDateTime(txtBegin.Value), Convert.ToDateTime(txtEnd.Value));
        }
    }
}