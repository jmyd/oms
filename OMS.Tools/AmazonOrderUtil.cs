using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.Tools
{
    public class AmazonOrderUtil : IOrderUtil
    {
        public void GetOrderByAPI(Core.DoMain.SaleAccountType account, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }



        public void GetOrderByFile(string fileName, Core.DoMain.SaleAccountType account)
        {
            CsvReader csv = new CsvReader(fileName, Encoding.Default);
            foreach (Dictionary<string, string> item in csv.ReadAllData())
            {
                OMS.Core.DoMain.OrderType order = Core.DoMain.OrderType.find("OrderExNo='" + item["order-id"] + "' and OrderForm='" + PlatformType.亚马逊.ToString() + "'").first();
                if (order != null)
                {
                    GetItem(item, order.Id.ToString());
                    continue;
                }
                order = new Core.DoMain.OrderType();
                order.OrderNo = OrderHelper.GetSequence();
                order.OrderExNo = item["order-id"];
                order.OrderForm = PlatformType.亚马逊.ToString();
                order.UserNameForm = account.UserName;
                order.ShippedStatus = "未发货";
                order.PayStatus = PayStatusType.已付款.ToString();
                order.OrderAmount = 0;
                order.OrderCurrencyCode = "USD";
                order.PayTime = wojilu.cvt.ToTime(item["purchase-date"]);
                order.AddTime = wojilu.cvt.ToTime(item["purchase-date"]);
                order.PayTime = wojilu.cvt.ToTime(item["purchase-date"]);
                order.PayTime = wojilu.cvt.ToTime(item["purchase-date"]);
                order.PayEmail = item["buyer-email"];
                order.PrintNum = 0;
                order.IsPrint = 0;
                order.BuyerCode = item["buyer-name"];
                order.BuyerId = OrderHelper.GetBuyer(order.BuyerCode, PlatformType.亚马逊).ToString();

                OMS.Core.DoMain.BuyerAddressType bat = new Core.DoMain.BuyerAddressType();
                bat.Street = item["ship-address-1"] + item["ship-address-2"] + item["ship-address-3"];
                bat.City = item["ship-city"];
                bat.StateOrProvince = item["ship-state"];
                bat.PostCode = item["ship-postal-code"];
                bat.Country = item["ship-country"];
                bat.CountryCode = item["ship-country"];
                bat.Email = item["buyer-email"];
                bat.Phone = item["buyer-phone-number"];
                bat.ContactMan = item["recipient-name"];
                bat.BuyerCode = order.BuyerCode;
                bat.BuyerId = order.BuyerId;
                OMS.Core.DoMain.BuyerAddressType bat2 = OMS.Core.DoMain.BuyerAddressType.find("ContactMan=:p1 and Street=:p2").set("p1", bat.ContactMan).set("p2", bat.Street).first();
                if (bat2 != null)
                {
                    order.AddressId = bat2.Id.ToString();
                }
                else
                {
                    bat.insert();
                    order.AddressId = bat.Id.ToString();
                }

                GetItem(item, order.Id.ToString());




            }
        }

        private static void GetItem(Dictionary<string, string> item, string id)
        {
            OMS.Core.DoMain.OrderGoodsType ogt = new Core.DoMain.OrderGoodsType();

            //ogt.ItemAttr = item[""];
            ogt.OrderNo = id;
            ogt.Sku = item["sku"];
            ogt.ItemName = item["product-name"];
            ogt.ItemNum = wojilu.cvt.ToInt(item["quantity-purchased"]);
            ogt.ItemPrice = 0;
            OMS.Core.DoMain.GoodsCoefficientType cf = OMS.Core.DoMain.GoodsCoefficientType.find("SaleSku='" + ogt.Sku + "'").first();
            if (cf != null && cf.Id != 0)
            {
                ogt.ItemNo = cf.ItemSku;
                ogt.ItemNum = cf.GoodsNum * ogt.ItemNum;
                ogt.ItemDesc = cf.Description;
            }
            ogt.insert();
        }
        public void SetPackage()
        {

        }

        public void SetShip()
        {

        }

        public void GetEbayStore(Core.DoMain.SaleAccountType account)
        {

        }

        public int GetOneOrderByAPI(Core.DoMain.SaleAccountType account, string orderId)
        {
            return 1;
        }
    }
}
