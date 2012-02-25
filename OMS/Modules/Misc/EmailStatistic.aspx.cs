using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using OMS.Core.DoMain;
using wojilu;

namespace OMS.Modules.Misc
{
    public partial class EmailStatistic : System.Web.UI.Page
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
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                RpRepliedListDataBind(DateTime.Now.Year, DateTime.Now.Month);
            }
        }

        private void RpRepliedListDataBind(int year, int month)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();
            startTime = new DateTime(year, month, 1, 0, 0, 0, 0);
            endTime = new DateTime(year, month, GetDaysOfMonth(year, month), 23, 59, 59, 999);

            List<SaleAccountType> saleAccountList = SaleAccountType.findAll();
            foreach (SaleAccountType sa in saleAccountList)
            {
                DataTable dt = db.RunTable<EmailType>("SELECT COUNT(1), CONVERT(varchar(10),CreateOn,120) AS CreateOn FROM Email WHERE CreateOn BETWEEN '" + startTime + "' AND '" + endTime + "' and SaleAccount ='" + sa.UserName + "' GROUP BY CONVERT(varchar(10),CreateOn,120) ORDER BY CreateOn ASC");
                
                StringBuilder output = new StringBuilder();

                string title = string.Format("{0}年{1}月", year, month);

                output.Append("<div id=\"chartdiv" + sa.UserName + "\" align=\"left\"></div>");
                output.Append("<script type=\"text/javascript\">");
                output.Append("var myChart" + sa.UserName + " = new FusionCharts(\"/Scripts/FusionCharts/FCF_Line.swf\", \"myChartId" + sa.UserName + "\", \"960\", \"300\");");
                output.Append("myChart" + sa.UserName + ".setDataXML(\"");
                output.Append("<graph yAxisName='Quantity' caption='" + sa.UserName + " 邮件数量统计(共{0}封,平均每天{1}封) ").Append(title).Append("'");
                output.Append(" showAlternateHGridColor='1' AlternateHGridColor='ff5904' divLineColor='ff5904'");
                output.Append(" divLineAlpha='20' alternateHGridAlpha='5' canvasBorderColor='666666'");
                output.Append(" baseFontColor='333333' lineThickness='3' bgColor='f1f1f1'");
                output.Append(" decimalPrecision='0' divlinedecimalPrecision='0' limitsdecimalPrecision='0' BaseFontSize = '12'>");
                int col = new Random().Next(0, 255);
                int totalQuantity = 0;
                foreach (DataRow row in dt.Rows)
                {
                    col += 20;
                    if (col > 255) col = col - 255;
                    int col1 = col + 60;
                    if (col1 > 255) col1 = col1 - 255;
                    int col2 = col + 90;
                    if (col2 > 255) col2 = col2 - 255;
                    string color = col.ToString("X") + col1.ToString("X") + col2.ToString("X");
                    output.Append("<set name='").Append(DateTime.Parse(row[1].ToString()).Day.ToString())
                        .Append("' value='").Append(int.Parse(row[0].ToString())).Append("' color='").Append(color.ToString()).Append("'/>");
                    totalQuantity += int.Parse(row[0].ToString());
                }
                int avgQuantity = 0;
                if (dt.Rows.Count > 0)
                {
                    avgQuantity = totalQuantity / dt.Rows.Count;
                }
                output.Append("</graph>\");");
                output.Append("myChart" + sa.UserName + ".render(\"chartdiv" + sa.UserName + "\");");
                output.Append("</script>");
                if (dt.Rows.Count > 0)
                {
                    div.InnerHtml += string.Format(output.ToString(), totalQuantity, avgQuantity) + "<br/>";
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(ddlYear.SelectedItem.Value);
            int month = int.Parse(ddlMonth.SelectedItem.Value);
            RpRepliedListDataBind(year, month);
        }


        protected void lbtnNowMonth_Click(object sender, EventArgs e)
        {
            RpRepliedListDataBind(DateTime.Now.Year, DateTime.Now.Month);
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