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
    public partial class EmailEdit : System.Web.UI.Page
    {
        private string strId = "";
        private EmailRepliedType re = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            strId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(strId))
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('非法访问！');location.href='RepliedEmailList.aspx'</script>");
                return;
            }
            re = EmailRepliedType.findById(int.Parse(strId));
            EmailType ce = EmailType.find("MessageID=" + re.MessageID).first();
            tbxContent.Text= ce.Body;
            lblOurStore.Text = ce.SaleAccount;
            lblFrom.Text = ce.BuyerAccount + "———" + ce.CreateOn.ToString();
            lblItemCurrency.Text = ce.ItemPriceCurrency;
            lblItemTitle.Text = ce.ItemTitle;
            lblItemValue.Text = ce.ItemPrice.ToString();
            lblMsgType.Text = ce.MessageType;
            lblSenderEmail.Text = ce.BuyerEmail;
            lblTitle.Text = ce.Subject;
            hlinkViewItem.NavigateUrl = ce.ItemURL;
            hlinkViewItem.Target = "_blank";
            txtEmailTitle.Text = re.Subject;
            tbxReply.Text = re.Body;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strEmailTitle = Request.Form[txtEmailTitle.ID].Trim();
            if (string.IsNullOrEmpty(strEmailTitle))
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('邮件标题不能为空！');</script>");
                return;
            }
            string strContent = Request.Form[tbxReply.ID].Trim();
            if (string.IsNullOrEmpty(strContent))
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('邮件内容不能为空！');</script>");
                return;
            }
            re.Subject = strEmailTitle;
            re.Body = strContent;
            re.update();            
        }
    }
}