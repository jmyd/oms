using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;

namespace OMS.Modules.Order
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //OrderType.findAll();


            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

        }
    }
}