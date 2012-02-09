using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Modules.Stock
{
    public partial class GoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DoPageLoad();
            }
        }

        private void DoPageLoad()
        {
            rpGoods.DataSource = OMS.Core.DoMain.GoodsType.findAll();
            rpGoods.DataBind();
        }

        protected void Submitbutton_Click(object sender, EventArgs e)
        {

        }


    }
}