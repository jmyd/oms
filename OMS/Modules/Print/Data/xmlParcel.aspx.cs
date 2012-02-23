using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wojilu;
using OMS.Core.DoMain;
using System.Data;

namespace OMS.Modules.Print.Data
{
    public partial class xmlParcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string sql = "";
                string Id = Request.QueryString["Id"];
                if (Id != null)
                {
                    OrderPrintRecordType oprt = OrderPrintRecordType.findById(cvt.ToInt(Id));
                    if (oprt != null)
                    {
                        sql = @"select (select COUNT(1) from PackageGoods where PackageGoods.PackageNo=p.PackageNo ) as GCount,p.PackageNo,o.TxnId,o.UserNameForm,o.OrderNo,o.OrderAmount,o.OrderCurrencyCode,o.OrderForm,o.OrderNote,p.LogisticsMode,
pg.Sku,pg.ItemQty,o.NowOrderType,b.*,g.ItemName
from Package p 
left join Orders o on p.OrderID=o.Id
left join BuyerAddress b on o.AddressId=b.Id
left join PackageGoods pg on p.PackageNo=pg.PackageNo
left join Goods g on pg.Sku=g.ItemSku
where o.Id in (" + oprt.OrderIds + ") and p.PackageStatus='未发货'";
                        DataSet ds = new DataSet();
                        DataTable dt = db.RunTable<OrderType>(sql);
                        dt.DefaultView.Sort = "GCount,PackageNo asc";
                        ds.Tables.Add(dt.DefaultView.ToTable());
                        string xml = ds.GetXml();
                        Utilities.ResponseXml(this, ref xml, false);
                    }
                }





            }
        }
    }
}