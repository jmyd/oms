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
                DDLInit();
                this.DoPageLoad();

            }
        }




        private void DoPageLoad()
        {

            string sqlWhere = string.Empty;
            sqlWhere += string.IsNullOrEmpty(HPlatform.Value) || HPlatform.Value == "ALL" ? "" : "OrderFrom='" + HPlatform.Value + "' and ";

            sqlWhere += string.IsNullOrEmpty(HAccount.Value) || HAccount.Value == "ALL" ? "" : "UserNameFrom='" + HPlatform.Value + "' and ";

            sqlWhere += "PayTime between '" + txtBegin.Text + "' and '" + txtEnd.Text + "' and ";

            sqlWhere += txtSearch.Value.Trim().Length > 0 ? " ( TxnId like '%" + txtSearch.Value.Trim() + "%' Or OrderNo='" + txtSearch.Value.Trim() + "' Or BuyerCode='" + txtSearch.Value.Trim() + "') " : "";

            if (sqlWhere.LastIndexOf("and") >= sqlWhere.Length - 4)
            {
                sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 4);
            }


            DataPage<OrderType> datapage = db.findPage<OrderType>(sqlWhere, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rpOrder.DataSource = datapage.Results;
            AspNetPager1.RecordCount = datapage.RecordCount;
            rpOrder.DataBind();
        }

        private void DDLInit()
        {
            txtBegin.Text = DateTime.Now.AddMonths(-2).ToString("yyyy-MM-dd HH:mm:ss");
            txtEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ddlPlatform.Items.Add(new ListItem("全部", "ALL"));
            foreach (string item in Enum.GetNames(typeof(OMS.Tools.PlatformType)))
            {
                ddlPlatform.Items.Add(new ListItem(item, item));
            }
            ddlPlatform.SelectedIndex = 0;
            ddlAccount.Items.Add(new ListItem("全部", "ALL"));
            foreach (SaleAccountType item in SaleAccountType.find(string.IsNullOrEmpty(HPlatform.Value) || HPlatform.Value == "ALL" ? "PlatformCode='" + HPlatform.Value + "'" : "").list())
            {
                ddlAccount.Items.Add(new ListItem(item.UserName, item.PlatformCode + ":" + item.UserName));
            }
            ddlAccount.SelectedIndex = 0;
            HPlatform.Value = ddlPlatform.SelectedValue;
            HAccount.Value = ddlAccount.SelectedValue;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DoPageLoad();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //查询
            DoPageLoad();

        }

        protected void lbPrint_Click(object sender, EventArgs e)
        {
            //获得打印的订单数

            OrderPrintRecordType oprt = new OrderPrintRecordType();
            oprt.CreateOn = DateTime.Now;
            oprt.Title = HAccount.Value + " " + DateTime.Now.ToLocalTime();

            oprt.OrderIds = Utilities.GetIds(db.RunTable<OrderType>("select id from Orders where IsPrint=0 and PrintNum=0 and ShippedStatus <> '已发货' and Enabled=0"));
            oprt.OrderNum = oprt.OrderIds.Split(',').Length;
            oprt.insert();
            string js = "$.dialog.confirm('是否转到订单打印页面？', function(){ window.open('OrderPrintRecord.aspx');});";
            Utilities.ShowJS(js);
        }

        protected void ddlPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            HPlatform.Value = ddlPlatform.SelectedValue;
            ddlAccount.Items.Add(new ListItem("全部", "ALL"));
            foreach (SaleAccountType item in SaleAccountType.find(string.IsNullOrEmpty(HPlatform.Value) || HPlatform.Value == "ALL" ? "PlatformCode='" + HPlatform.Value + "'" : "").list())
            {
                ddlAccount.Items.Add(new ListItem(item.UserName, item.PlatformCode + ":" + item.UserName));
            }
            ddlAccount.SelectedIndex = 0;
            ddlAccount_SelectedIndexChanged(null, null);
        }

        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            HAccount.Value = ddlAccount.SelectedValue;
        }




    }
}