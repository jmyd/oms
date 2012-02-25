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
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace OMS.Modules.Misc
{
    public partial class Reply : System.Web.UI.Page
    {
        private string strId = "";
        private EmailType ce = null;
        private string currentEbayAccount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strId = Request.QueryString["id"];
            currentEbayAccount = Request.QueryString["ea"];

            if (string.IsNullOrEmpty(strId))
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('非法访问！');location.href='Default.aspx';</script>");
                return;
            }
            ce = EmailType.findById(int.Parse(strId));
            if (ce.MessageStatus == "Replied")
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script language='javascript' type='text/javascript'>alert('该Email已回复！');EmailListReload();</script>");
                return;
            }

            List<OrderType> listOrder = OrderType.find("BuyerId='" + ce.BuyerAccount + "' and UserNameForm='" + ce.SaleAccount + "' and CreateOn>'" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'").list();
            for (int i = 0; i < listOrder.Count; i++)
            {
                listOrder[i].OrderGoods = OrderGoodsType.find("OrderNo='" + listOrder[i].Id + "'").list();
            }
            rpOrderInfo.DataSource = listOrder;
            rpOrderInfo.DataBind();

            DateTime limitTime = DateTime.Now.AddDays(-90);
            
            DataTable dtHistory = db.RunTable<EmailType>("SELECT E.BuyerAccount,E.[Subject],E.[Body],E.[CreateOn],RE.[Replier],RE.[Subject],RE.[Body],RE.CreateOn FROM [Email] AS E LEFT JOIN [EmailReplied] AS RE ON E.MessageID = RE.MessageID WHERE E.BuyerAccount='" + ce.BuyerAccount + "' AND E.SaleAccount='" + ce.SaleAccount + "' AND E.CreateOn>'" + limitTime + "' ORDER BY E.CreateOn ASC");
            List<EmailRepliedType> result = new List<EmailRepliedType>();
            foreach (DataRow dr in dtHistory.Rows)
            {
                EmailRepliedType re = new EmailRepliedType();
                re.Replier = dr[0].ToString();
                re.Subject=dr[1].ToString();
                re.Body = dr[2].ToString();
                re.CreateOn = DateTime.Parse(dr[3].ToString());
                re.IsToEbay = false;
                result.Add(re);
                re = new EmailRepliedType();
                if (!dr.IsNull(4))
                {
                    re.Replier = dr[4].ToString();
                    re.Subject = dr[5].ToString();
                    re.Body = dr[6].ToString();
                    re.CreateOn = DateTime.Parse(dr[7].ToString());
                    re.IsToEbay = true;
                    result.Add(re);
                }
            }

            rpHistoryEmail.DataSource = result;
            rpHistoryEmail.DataBind();

            lblOurStore.Text = ce.SaleAccount;
            lblItemCurrency.Text = ce.ItemPriceCurrency;
            lblItemTitle.Text = ce.ItemTitle;
            lblItemValue.Text = ce.ItemPrice.ToString();
            lblMsgType.Text = ce.MessageType;
            lblSenderEmail.Text = ce.BuyerEmail.Replace("@", " @");
            hlinkViewItem.NavigateUrl = ce.ItemURL;
            hlinkViewItem.Target = "_blank";
            txtEmailTitle.Text = ce.Subject;

            hdStartTime.Value = DateTime.Now.ToString();
        }


        private void SaveCurrentReply()
        {
            string strEmailTitle = Request.Form[txtEmailTitle.ID].Trim();
            string strContent = Request.Form[tbxReply.ID].Trim();
            EmailRepliedType re = new EmailRepliedType();
            if (strContent.Length > 0)
            {
                re.Body = strContent + "\r\n\r\n---" + "";//当前用户名
            }
            else
            {
                re.Body = "";
            }
            re.CreateOn = DateTime.Now;
            re.ReceiveOn = ce.CreateOn;
            re.SaleAccount = ce.SaleAccount;
            re.ItemID = ce.ItemID;
            re.Subject = strEmailTitle;            
            re.IsToEbay = false;                        
            re.MessageID = ce.MessageID;
            re.Replier = "";//当前用户名
            re.BuyerEmail = ce.BuyerEmail;
            re.BuyerAccount = ce.BuyerAccount;
            re.ToEbayOn = new DateTime(1999, 1, 1, 0, 0, 0, 0);

            string strStartTime = Request.Form[hdStartTime.ID].Trim();
            DateTime startTime = DateTime.Parse(strStartTime);
            re.ReplyCostSecond = (re.CreateOn - startTime).TotalSeconds;
            re.insert();
            ce.MessageStatus = "Replied";
            ce.update();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveCurrentReply();
            Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script language='javascript' type='text/javascript'>EmailListReload();</script>");
        }

        protected void btnPrefix_Click(object sender, EventArgs e)
        {
            SaveCurrentReply();
            GetOtherCustomerEmail("PRE");

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            GetOtherCustomerEmail("NEXT");
        }

        protected void btnSendAndNext_Click(object sender, EventArgs e)
        {
            SaveCurrentReply();
            GetOtherCustomerEmail("NEXT");
        }

        private void GetOtherCustomerEmail(string sortString)
        {
            EmailType ceOther = null;
            string msg = "";
            if (sortString == "PRE")
            {
                msg = "已经是第一封！";
            }
            else if (sortString == "NEXT")
            {
                msg = "已经是最后一封！";
            }
            string account = "";
            List<SaleAccountType> saleAccountList = SaleAccountType.findAll();            
            foreach (SaleAccountType sa in saleAccountList)
            {                
                account += "'" + sa.UserName + "',";
            }
            if (!string.IsNullOrEmpty(currentEbayAccount))
            {
                currentEbayAccount = "'" + currentEbayAccount + "'";
                ceOther = GetOtherEmailByParameters(currentEbayAccount, ce.CreateOn, sortString);
            }
            else
            {
                ceOther = GetOtherEmailByParameters(account.TrimEnd(','), ce.CreateOn, sortString);
            }
            if (ceOther != null)
            {
                if (!string.IsNullOrEmpty(currentEbayAccount))
                {
                    Response.Redirect("Reply.aspx?id=" + ceOther.Id + "&ea=" + currentEbayAccount);
                }
                else
                {
                    Response.Redirect("Reply.aspx?id=" + ceOther.Id);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>");
            }
        }

        private EmailType GetOtherEmailByParameters(string ebayAccount, DateTime createTime, string sortStr)
        {
            EmailType ce = null;
            DateTime limitTime = DateTime.Now.AddDays(-90);
            if (createTime < limitTime)
            {
                createTime = limitTime;
            }
            string sqlParam = " AND SaleAccount IN(" + ebayAccount + ")";
            if (sortStr == "PRE")
            {
                sqlParam += " AND [CreateOn] > '" + limitTime + "' ORDER BY [CreateOn] ASC";
            }
            else if (sortStr == "NEXT")
            {
                sqlParam += " AND [CreateOn] < '" + limitTime + "' ORDER BY [CreateOn] DESC";
            }
            string sql = "SELECT TOP 1 * FROM [Email] WHERE [MessageStatus] ='Unanswered'" + sqlParam;
            List<EmailType> result = EmailType.findBySql(sql);
            foreach (EmailType e in result)
            {
                ce = e;
                break;
            }
            return ce;
        }
    }
}