using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using wojilu;
using OMS.Core.DoMain;
using System.Data;

namespace OMS.Modules.Misc
{
    public partial class EmailRepliedRank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CompanyCode"] = "OMSTest";
                int year = DateTime.Now.Year;
                for (int y = (year - 1); y <= (year + 1); y++)
                {
                    ddlYear.Items.Add(new ListItem(y.ToString(), y.ToString()));
                }
                for (int m = 1; m <= 12; m++)
                {
                    ddlMonth.Items.Add(new ListItem(m.ToString(), m.ToString()));
                }
                for (int d = 1; d <= 31; d++)
                {
                    ddlDay.Items.Add(new ListItem(d.ToString(), d.ToString()));
                }
                ddlDay.Items.Add(new ListItem("0", "0"));
                ddlDay.SelectedValue = DateTime.Now.Day.ToString();
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                RpRepliedListDataBind(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        private void RpRepliedListDataBind(int year, int month, int day)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();
            if (day > 0)
            {
                startTime = new DateTime(year, month, day, 0, 0, 0, 0);
                int dayOfMonth = GetDaysOfMonth(year, month);
                if (day > dayOfMonth)
                {
                    day = dayOfMonth;
                }
                endTime = new DateTime(year, month, day, 23, 59, 59, 999);
            }
            else
            {
                startTime = new DateTime(year, month, 1, 0, 0, 0, 0);
                endTime = new DateTime(year, month, GetDaysOfMonth(year, month), 23, 59, 59, 999);
            }

            string sqlRe = "SELECT Replier, COUNT(1) AS Quantity, AVG(ReplyCostSecond) As RCS FROM EmailReplied WHERE CreateOn >='" + startTime + "' AND CreateOn<='" + endTime + "' AND IsToEbay = 1 GROUP BY Replier ORDER BY Quantity DESC";
            DataTable dtRe = db.RunTable<EmailRepliedType>(sqlRe);

            foreach (DataRow dr in dtRe.Rows)
            {
                dtRe.Columns.Add("RealName", typeof(string));
                dr["RealName"] = UserType.find("Username = "+dr[0].ToString()).first();
            }            
            rpRepliedList.DataSource = dtRe;
            rpRepliedList.DataBind();

            StringBuilder output = new StringBuilder();

            string title = "";
            if (day > 0)
            {
                title = string.Format("{0}年{1}月{2}日", year, month, day);
            }
            else
            {
                title = string.Format("{0}年{1}月", year, month);
            }
            output.Append("<div id=\"chartdiv0\" align=\"left\"></div>");
            output.Append("<script type=\"text/javascript\">");
            output.Append("var myChart0 = new FusionCharts(\"../FusionCharts/FCF_Column2D.swf\", \"myChartId0\", \"570\", \"300\");");
            output.Append("myChart0.setDataXML(\"");
            output.Append("<graph yAxisName='Quantity' caption='回邮件数量统计(共{0}封) ").Append(title).Append("'");
            output.Append(" showAlternateHGridColor='1' AlternateHGridColor='ff5904' divLineColor='ff5904'");
            output.Append(" divLineAlpha='20' alternateHGridAlpha='5' canvasBorderColor='666666'");
            output.Append(" baseFontColor='333333' lineThickness='3' bgColor='f1f1f1'");
            output.Append(" decimalPrecision='0' divlinedecimalPrecision='0' limitsdecimalPrecision='0' BaseFontSize = '12'>");
            int col = new Random().Next(0, 255);
            int totalQuantity = 0;
            int i = 1;
            foreach (DataRow dr in dtRe.Rows)
            {
                col += 20;
                if (col > 255) col = col - 255;
                int col1 = col + 60;
                if (col1 > 255) col1 = col1 - 255;
                int col2 = col + 90;
                if (col2 > 255) col2 = col2 - 255;
                string color = col.ToString("X") + col1.ToString("X") + col2.ToString("X");
                output.Append("<set name='").Append(dr["RealName"].ToString())
                    .Append("' value='").Append(dr["Quantity"].ToString()).Append("' color='").Append(color.ToString()).Append("'/>");
                totalQuantity += int.Parse(dr["Quantity"].ToString());
            }
            output.Append("</graph>\");");
            output.Append("myChart0.render(\"chartdiv0\");");
            output.Append("</script>");

            divMail.InnerHtml = string.Format(output.ToString(), totalQuantity);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(ddlYear.SelectedItem.Value);
            int month = int.Parse(ddlMonth.SelectedItem.Value);
            int day = int.Parse(ddlDay.SelectedItem.Value);
            RpRepliedListDataBind(year, month, day);
        }
        protected void btnNowDay_Click(object sender, EventArgs e)
        {
            RpRepliedListDataBind(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        protected void lbtnNowMonth_Click(object sender, EventArgs e)
        {
            RpRepliedListDataBind(DateTime.Now.Year, DateTime.Now.Month, 0);
        }

        private int GetDaysOfMonth(int y, int m)
        {
            int days = 0;
            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                case 2:
                    days = GetFebDays(y);
                    break;
            }
            return days;
        }

        private int GetFebDays(int y)
        {
            if (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0))
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
    }
}