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
    public partial class DisputeApproach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DisputeApproachType at = new DisputeApproachType();
            string approachName = Request.Form[txtApproachName.ID].Trim();
            if (string.IsNullOrEmpty(approachName))
            {
                return;
            }
            at.ApproachName = approachName;
            at.insert();
        }
    }
}