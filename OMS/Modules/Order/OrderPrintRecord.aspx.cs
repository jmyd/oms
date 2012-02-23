using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Modules.Order
{
    public partial class OrderPrintRecord : System.Web.UI.Page
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
            wojilu.DataPage<OMS.Core.DoMain.OrderPrintRecordType> dataPage = wojilu.db.findPage<OMS.Core.DoMain.OrderPrintRecordType>("Order By CreateOn Desc", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rpRecord.DataSource = dataPage.Results;
            AspNetPager1.RecordCount = dataPage.RecordCount;
            rpRecord.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DoPageLoad();
        }
    }
}