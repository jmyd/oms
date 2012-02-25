using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Core.DoMain;
using wojilu;
using Wuqi.Webdiyer;
using System.Data;
using System.Text;

namespace OMS.Modules.Misc
{
    public partial class RepliedEmailList : System.Web.UI.Page
    {
        protected string accountLink = "";
        private string account = "";
        private string currentEbayAccount = "";
        private DateTime minTime = new DateTime(1999, 1, 1);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CompanyCode"] = "OMSTest";
                List<SaleAccountType> saleAccountList = SaleAccountType.findAll();
                foreach (SaleAccountType sa in saleAccountList)
                {
                    accountLink += " <a href='RepliedEmailList.aspx?ea=" + sa.UserName + "'>" + sa.UserName + "</a>" + " | ";
                    account += "'" + sa.UserName + "',";
                }
                accountLink += " <a href='RepliedEmailList.aspx'>全部</a>";
                RpEmailDataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RpEmailDataBind();
        }

        private void RpEmailDataBind()
        {
            string sDate = Request.QueryString["sd"];
            string eDate = Request.QueryString["ed"];
            string sHour = Request.QueryString["sh"];
            string eHour = Request.QueryString["eh"];
            int startHour = 0;
            int endHour = 23;
            if (int.TryParse(sHour, out startHour))
            {
                if (startHour < 0)
                {
                    startHour = 0;
                }
                else if (startHour > 23)
                {
                    startHour = 23;
                }
            }
            if (int.TryParse(eHour, out endHour))
            {
                if (endHour < 0)
                {
                    endHour = 0;
                }
                else if (endHour > 23)
                {
                    endHour = 23;
                }
            }

            DateTime startTime = new DateTime();
            if (string.IsNullOrEmpty(sDate))
            {
                startTime = minTime;
            }
            else
            {
                startTime = DateTime.Parse(sDate);
                startTime = startTime.AddHours(startHour);
            }

            DateTime endTime = new DateTime();
            if (string.IsNullOrEmpty(eDate))
            {
                endTime = minTime;
            }
            else
            {
                endTime = DateTime.Parse(eDate);
                endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, endHour, 59, 59, 999);
            }

            string senderId = Request.QueryString["sid"];
            string searchKey = Request.QueryString["sk"];
            string ebayAccount = Request.QueryString["ea"];
            currentEbayAccount = ebayAccount;

            txtStartDate.Value = sDate;
            txtEndDate.Value = eDate;
            txtStartHour.Text = sHour;
            txtEndHour.Text = eHour;
            txtSenderId.Text = senderId;
            txtSearchKey.Text = searchKey;
            hdEbayAccount.Value = ebayAccount;

            DateTime limitTime = DateTime.Now.AddDays(-90);

            string sqlParam = " [CreateOn] >= '" + limitTime + "'";

            if (startTime > minTime && endTime > minTime)
            {
                sqlParam += " AND [CreateOn] BETWEEN '" + startTime + "' AND '" + endTime + "'";
            }
            else if (startTime > minTime && endTime <= minTime)
            {
                sqlParam += " AND [CreateOn] >= '" + startTime + "' ";
            }
            else if (startTime <= minTime && endTime > minTime)
            {
                sqlParam += " AND [CreateOn] <= '" + endTime + "'";
            }
            if (!string.IsNullOrEmpty(senderId))
            {
                sqlParam += " AND [BuyerAccount]='" + senderId + "'";
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                sqlParam += " AND [Body] LIKE '%" + searchKey + "%'";
            }          
            if (!string.IsNullOrEmpty(ebayAccount))
            {
                sqlParam += " AND [SaleAccount] IN ('" + ebayAccount + "')";
            }
            else
            {
                string dp = account.TrimEnd(',');
                sqlParam += " AND [SaleAccount] IN (" + dp + ")";
            }

            AspNetPager1.RecordCount = EmailRepliedType.count(sqlParam);
            DataPage<EmailRepliedType> dpEmailType = db.findPage<EmailRepliedType>("" + sqlParam + " ORDER BY CreateOn DESC", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rpEmail.DataSource = dpEmailType.Results;
            rpEmail.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sDate = Request.Form[txtStartDate.ID].Trim();
            string eDate = Request.Form[txtEndDate.ID].Trim();

            DateTime startTime = new DateTime();
            if (string.IsNullOrEmpty(sDate))
            {
                startTime = minTime;
            }
            else
            {
                startTime = DateTime.Parse(sDate);
            }

            DateTime endTime = new DateTime();
            if (string.IsNullOrEmpty(eDate))
            {
                endTime = minTime;
            }
            else
            {
                endTime = DateTime.Parse(eDate);
                endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59, 999);
            }

            string senderId = Request.Form[txtSenderId.ID].Trim();
            string searchKey = Request.Form[txtSearchKey.ID].Trim();
            string sHour = Request.Form[txtStartHour.ID].Trim();
            string eHour = Request.Form[txtEndHour.ID].Trim();
            string ebayAccount = Request.Form[hdEbayAccount.ID].Trim();

            Response.Redirect("EmailList.aspx?sd=" + sDate + "&ed=" + eDate + "&sh=" + sHour + "&eh=" + eHour + "&sid=" + senderId + "&sk=" + searchKey + "&ea=" + ebayAccount);
        }

        protected void rpEmial_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblBody = (Label)e.Item.FindControl("lblBody");
            StringBuilder sb = new StringBuilder();
            sb.Append("<a onclick=");
            sb.Append('"');
            sb.Append("Edit('url:EmailEdit.aspx?id=");
            sb.Append(((EmailRepliedType)e.Item.DataItem).Id.ToString());
            sb.Append("&ea=");
            sb.Append(currentEbayAccount);
            sb.Append("')");
            sb.Append('"');
            sb.Append(" href='#'>");
            sb.Append(CutString(((EmailRepliedType)e.Item.DataItem).Body, 60));
            sb.Append("</a>");
            
            lblBody.Text = sb.ToString();
          
        }

        private string CutString(string oldString, int limitLength)
        {
            if (oldString.Length > limitLength)
            {
                return oldString.Substring(0, limitLength) + "…";
            }
            else
            {
                return oldString;
            }
        }
    }
}