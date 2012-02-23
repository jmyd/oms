using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;
using wojilu;
using Wuqi.Webdiyer;

namespace OMS.Modules.Misc
{
    public partial class DisputeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Session["CompanyCode"] = "OMSTest";
                RpDisputDatabind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RpDisputDatabind();
        }

        private void RpDisputDatabind()
        {
            AspNetPager1.RecordCount = DisputeType.count();
            DataPage<DisputeType> dp = db.findPage<DisputeType>("", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rpDispute.DataSource = dp.Results;
            rpDispute.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int disputeId = 0;
            string sId = Request.Form[hId.ID].Trim();

            if (!string.IsNullOrEmpty(sId) && int.TryParse(sId, out disputeId))
            {
                DisputeType.delete(disputeId);
            }
        }
    }
}