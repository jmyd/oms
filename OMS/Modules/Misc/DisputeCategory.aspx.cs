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
    public partial class DisputeCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DisputeCategoryType ct = new DisputeCategoryType();
            string categoryName = Request.Form[txtCategoryName.ID].Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                return;
            }
            ct.CateName = categoryName;
            ct.insert();
        }
    }
}