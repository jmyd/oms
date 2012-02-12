using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;
using wojilu;

namespace OMS.Modules.Order
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CompanyCode"] = "OMSTest";
                this.DoPageLoad();

            }
        }

        private void DoPageLoad()
        {
            DataPage<OrderType> datapage = db.findPage<OrderType>("", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rpOrder.DataSource = datapage.Results;
            AspNetPager1.RecordCount = datapage.RecordCount;
            rpOrder.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DoPageLoad();
        }
    }
}