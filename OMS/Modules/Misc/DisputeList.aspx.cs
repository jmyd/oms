﻿using System;
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
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

        }
    }
}