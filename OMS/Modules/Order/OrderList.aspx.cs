using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OMS.Core.DoMain;
using wojilu;
using System.Data;

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //查询
            DateTime dtBegin = cvt.ToTime(txtBegin.Text);
            DateTime dtEnd = cvt.ToTime(txtEnd.Text);
            string key = txtSearch.Value.Trim();

        }

        protected void lbPrint_Click(object sender, EventArgs e)
        {
            //获得打印的订单数

            OrderPrintRecordType oprt = new OrderPrintRecordType();
            oprt.CreateOn = DateTime.Now;
            oprt.Title = HAccount.Value;
            int num = OrderType.count("PayTime between '" + txtBegin.Text + "' and '" + txtEnd.Text + "' and IsPrint=0 and ShippedStatus <>'已发货'");

            oprt.OrderIds = Utilities.GetIds(db.RunTable<OrderType>("select id from Orders where IsPrint=0 and PrintNum=0 and ShippedStatus <> '已发货' and Enabled=0"));
            oprt.OrderNum = oprt.OrderIds.Split(',').Length;
            oprt.insert();
            //string js = "$.dialog.confirm('你确定要打印账号jinbostore的订单吗？', function(){ window.open('" + Utilities.GetPrintPath("Parcel", "xmlParcel.aspx") + "');});";
            //Utilities.ShowJS(js);
        }




    }
}