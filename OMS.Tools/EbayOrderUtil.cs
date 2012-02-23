using System;
using System.Collections.Generic;
using System.Text;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using com.paypal.sdk.profiles;

namespace OMS.Tools
{
    public class EbayOrderUtil : IOrderUtil
    {
        public void GetOrderByAPI(Core.DoMain.SaleAccountType account, DateTime beginDate, DateTime endDate)
        {
            ApiContext context = AppSettingHelper.GetGenericApiContext("US");
            context.ApiCredential.eBayToken = account.ApiToken;
            eBay.Service.Call.GetOrdersCall apicall = new eBay.Service.Call.GetOrdersCall(context);
            apicall.IncludeFinalValueFee = true;
            apicall.DetailLevelList.Add(eBay.Service.Core.Soap.DetailLevelCodeType.ReturnAll);
            apicall.ModTimeFrom = beginDate;
            apicall.ModTimeTo = endDate;
            eBay.Service.Core.Soap.OrderTypeCollection m = null;
            int i = 1;
            do
            {
                apicall.Pagination = new eBay.Service.Core.Soap.PaginationType();
                apicall.Pagination.PageNumber = i;
                apicall.Pagination.EntriesPerPage = 100;
                apicall.OrderRole = eBay.Service.Core.Soap.TradingRoleCodeType.Seller;
                apicall.OrderStatus = eBay.Service.Core.Soap.OrderStatusCodeType.Completed;
                apicall.Execute();
                m = apicall.OrderList;
                for (int k = 0; k < m.Count; k++)
                {

                    OrderType ot = m[k];
                    OMS.Core.DoMain.OrderType order = OMS.Core.DoMain.OrderType.find("OrderExNo=:t1").set("t1", ot.OrderID).first();

                    if (order == null)
                        order = new Core.DoMain.OrderType();
                    else
                    {
                        if (order.ModifiedOn == ot.CheckoutStatus.LastModifiedTime)
                            continue;
                    }

                    order.OrderExNo = ot.OrderID;
                    order.OrderForm = PlatformType.Ebay.ToString();
                    order.UserNameForm = account.UserName;

                    order.PayStatus = ot.PaidTime == DateTime.MinValue ? PayStatusType.未付款.ToString() : PayStatusType.已付款.ToString();
                    order.PayTime = ot.PaidTime;
                    order.Payment = ot.CheckoutStatus.PaymentMethod.ToString();
                    order.ShippedStatus = ot.ShippedTime == DateTime.MinValue ? "未发货" : "已发货";
                    order.OrderNote = ot.BuyerCheckoutMessage;
                    order.OrderCurrencyCode = ot.AmountPaid.currencyID.ToString();
                    order.OrderAmount = ot.AmountPaid.Value;
                    order.BuyerCode = ot.BuyerUserID;
                    order.TxnId = ot.ExternalTransaction[0].ExternalTransactionID;
                    order.NowOrderType = NowOrderType.普通.ToString();
                    order.ModifiedOn = ot.CheckoutStatus.LastModifiedTime;
                    order.CreateOn = ot.CreatedTime;
                    order.CreateBy = "OMS_Auto";
                    order.ModifiedBy = "OMS_Auto";
                    //order.SendState = "未发货";
                    ////ebay发货地址设置
                    //order.SendAddress = ot.ShippingAddress.Street + " " + ot.ShippingAddress.Street1 + ot.ShippingAddress.Street2;
                    //order.SendCity = ot.ShippingAddress.CityName;
                    //order.SendCounty = ot.ShippingAddress.StateOrProvince;
                    //order.SendCountryCode = ot.ShippingAddress.Country.ToString();
                    //order.SendCountry = ot.ShippingAddress.CountryName;
                    //order.SendPhone = ot.ShippingAddress.Phone;
                    //order.SendPostCode = ot.ShippingAddress.PostalCode;
                    //order.ContactMan = ot.ShippingAddress.Name;
                    //if (!string.IsNullOrEmpty(ot.ShippingAddress.FirstName) || !string.IsNullOrEmpty(ot.ShippingAddress.LastName))
                    //{
                    //    order.ContactMan += "(" + ot.ShippingAddress.FirstName + ot.ShippingAddress.LastName + ")";
                    //}
                    //判断买家是不是存在
                    GetBuyer(order);

                    //订单中的产品
                    GetPaypals();

                    GetPaypalAddress(order);

                    foreach (TransactionType tran in ot.TransactionArray)
                    {
                        order.OrderSaleTax += tran.FinalValueFee.Value;
                    }
                    if (ot.TransactionArray.Count > 1)
                    {
                        order.NowOrderType = NowOrderType.多物品.ToString();
                    }

                    order.OrderNo = GetSequence();
                    order.insert();

                    GetItems(ot, order);

                    //获得未打印，为发货，可以合并的订单
                    List<OMS.Core.DoMain.OrderType> list = OMS.Core.DoMain.OrderType.find("AddressId=:p1 and IsPrint=0 and ShippedStatus='未发货' and Enabled=0").set("p1", order.AddressId).list();
                    if (list.Count <= 1)
                    {
                        //当只有一条时，无法合并

                        OMS.Core.DoMain.PackageType pt1 = new Core.DoMain.PackageType();
                        pt1.OrderID = order.Id;
                        pt1.OrderNo = order.OrderNo;
                        pt1.PackageNo = GetPackageSequence();
                        pt1.PackageStatus = "未发货";
                        pt1.CreateOn = DateTime.Now;
                        pt1.insert();

                        foreach (OMS.Core.DoMain.OrderGoodsType foo in order.OrderGoods)
                        {
                            OMS.Core.DoMain.PackageGoodsType pgt = new Core.DoMain.PackageGoodsType();
                            pgt.PackageNo = pt1.PackageNo;
                            pgt.Sku = foo.ItemNo;
                            pgt.ItemQty = foo.ItemNum;
                            pgt.insert();
                        }
                        continue;
                    }

                    OMS.Core.DoMain.OrderType orderType = list.Find(p => p.NowOrderType == NowOrderType.合并.ToString());//获取里面的合并订单

                    if (orderType == null)
                    {//没有合并订单时，数据初始化
                        orderType = order;
                        orderType.NowOrderType = NowOrderType.合并.ToString();
                        orderType.Id = 0;
                        orderType.TxnId = "";
                        orderType.OrderExNo = "";
                        orderType.OrderPayTax = 0;
                        orderType.OrderAmount = 0;
                        orderType.OrderSaleTax = 0;
                        orderType.OrderNote = "";

                    }
                    else
                    {
                        //有订单时，删除
                        wojilu.db.RunSql<OMS.Core.DoMain.PackageType>("delete from PackageGoods where PackageNo In(select PackageNo from Package where  OrderID=" + orderType.Id + ")");
                        wojilu.db.RunSql<OMS.Core.DoMain.PackageType>("delete from Package where OrderID=" + orderType.Id + "");
                        orderType.delete();

                    }
                    List<OMS.Core.DoMain.OrderGoodsType> OrderGoods = new List<Core.DoMain.OrderGoodsType>();

                    foreach (OMS.Core.DoMain.OrderType item in list)
                    {
                        //合并订单要合并的数据
                        orderType.OrderPayTax += item.OrderPayTax;
                        orderType.OrderAmount += item.OrderAmount;
                        orderType.OrderSaleTax += item.OrderSaleTax;
                        orderType.OrderNote += item.OrderNote;
                        orderType.Mergerorders += "," + item.Id;//订单指向

                        OrderGoods.AddRange(item.OrderGoods);
                    }
                    orderType.Mergerorders = orderType.Mergerorders.Trim(',');
                    orderType.OrderNo = GetSequence();//获取新的订单号
                    orderType.insert();
                    wojilu.db.RunSql<OMS.Core.DoMain.OrderType>("update Orders set Enabled =1 , Mergerorders='" + orderType.Id + "' where Id in(" + orderType.Mergerorders + ")");


                    wojilu.db.RunSql<OMS.Core.DoMain.PackageGoodsType>("delete from PackageGoods where PackageNo In(select PackageNo from Package where  OrderID in (" + orderType.Mergerorders
 + "))");
                    wojilu.db.RunSql<OMS.Core.DoMain.PackageType>("delete from Package where OrderID in(" + orderType.Mergerorders + ")");
                    foreach (OMS.Core.DoMain.OrderGoodsType foo in OrderGoods)
                    {
                        //产品转移
                        foo.OrderNo = orderType.Id.ToString();
                        foo.insert();
                    }

                    //生成包裹
                    OMS.Core.DoMain.PackageType pt = new Core.DoMain.PackageType();
                    pt.OrderID = orderType.Id;
                    pt.OrderNo = order.OrderNo;
                    pt.PackageNo = GetPackageSequence();
                    pt.PackageStatus = "未发货";
                    pt.CreateOn = DateTime.Now;
                    pt.insert();

                    foreach (OMS.Core.DoMain.OrderGoodsType foo in OrderGoods)
                    {
                        OMS.Core.DoMain.PackageGoodsType pgt = new Core.DoMain.PackageGoodsType();
                        pgt.PackageNo = pt.PackageNo;
                        pgt.Sku = foo.ItemNo;
                        pgt.ItemQty = foo.ItemNum;
                        pgt.insert();
                    }
                }
                i++;
            } while (m != null && m.Count == 100);

        }

        private static void GetBuyer(OMS.Core.DoMain.OrderType order)
        {
            OMS.Core.DoMain.BuyerType bt = OMS.Core.DoMain.BuyerType.find("BuyerCode='" + order.BuyerCode + "' and  PlatformCode ='" + PlatformType.Ebay.ToString() + "'").first();
            if (bt == null)
            {
                bt = new Core.DoMain.BuyerType();
                //不存在是的操作
                bt.BuyerCode = order.BuyerCode;
                bt.PlatformCode = PlatformType.Ebay.ToString();

                bt.BuyCount++;
                bt.insert();
            }
            else
            {
                bt.BuyCount++;
                bt.update();
            }
            order.BuyerId = bt.Id.ToString();
        }

        public string GetSequence()
        {
            string Sequence = string.Empty;
            OMS.Core.DoMain.SerialNumberType snt = OMS.Core.DoMain.SerialNumberType.find("FullName='OrderNo'").first();
            snt.Sequence = snt.Sequence + snt.Step;
            Sequence = snt.Prefix + snt.Sequence + snt.Separator;
            snt.update();
            return Sequence;
        }

        public string GetPackageSequence()
        {
            string Sequence = string.Empty;
            OMS.Core.DoMain.SerialNumberType snt = OMS.Core.DoMain.SerialNumberType.find("FullName='PackageNo'").first();
            snt.Sequence = snt.Sequence + snt.Step;
            Sequence = snt.Prefix + snt.Sequence + snt.Separator;
            snt.update();
            return Sequence;
        }

        private void GetPaypalAddress(OMS.Core.DoMain.OrderType order)
        {
            foreach (IAPIProfile item in paypals)
            {
                //获得paypal地址
                com.paypal.soap.api.GetTransactionDetailsResponseType transactionDetails = AppSettingHelper.GetTransactionDetails(order.TxnId, item);
                if (transactionDetails.Ack == com.paypal.soap.api.AckCodeType.Success || transactionDetails.Ack == com.paypal.soap.api.AckCodeType.SuccessWithWarning)
                {
                    OMS.Core.DoMain.BuyerAddressType bat = new Core.DoMain.BuyerAddressType();
                    bat.Street = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.Street1 + " " + transactionDetails.PaymentTransactionDetails.PayerInfo.Address.Street2;
                    bat.City = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.CityName;
                    bat.StateOrProvince = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.StateOrProvince;
                    bat.CountryCode = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.Country.ToString();
                    bat.Country = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.CountryName;
                    bat.PostCode = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.PostalCode;
                    bat.ContactMan = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.Name;
                    bat.Email = transactionDetails.PaymentTransactionDetails.PayerInfo.Payer;
                    bat.Phone = transactionDetails.PaymentTransactionDetails.PayerInfo.ContactPhone;
                    order.PayEmail = transactionDetails.PaymentTransactionDetails.ReceiverInfo.Business;
                    order.OrderPayTax = Convert.ToDouble(transactionDetails.PaymentTransactionDetails.PaymentInfo.FeeAmount.Value);
                    order.PayCurrencyCode = transactionDetails.PaymentTransactionDetails.PaymentInfo.FeeAmount.currencyID.ToString();
                    bat.BuyerCode = order.BuyerCode;
                    bat.BuyerId = order.BuyerId;
                    order.Description = transactionDetails.PaymentTransactionDetails.PayerInfo.Address.CountryName;
                    //判断该地址是否保存在数据库中.
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

                    break;
                }
            }
        }

        private static void GetItems(OrderType ot, OMS.Core.DoMain.OrderType order)
        {
            foreach (TransactionType tran in ot.TransactionArray)
            {
                OMS.Core.DoMain.OrderGoodsType ogt = new Core.DoMain.OrderGoodsType();

                ogt.ItemAttr = tran.OrderLineItemID;
                ogt.OrderNo = order.Id.ToString();
                ogt.Sku = tran.Item.ItemID;
                ogt.ItemName = tran.Item.Title;
                ogt.ItemNum = tran.QuantityPurchased;
                ogt.ItemPrice = tran.TransactionPrice.Value;
                OMS.Core.DoMain.GoodsCoefficientType cf = OMS.Core.DoMain.GoodsCoefficientType.find("SaleSku='" + ogt.Sku + "'").first();
                if (cf != null && cf.Id != 0)
                {
                    ogt.ItemNo = cf.ItemSku;
                    ogt.ItemNum = cf.GoodsNum * ogt.ItemNum;
                }
                else
                {
                    string sku = ogt.ItemName.Substring(ogt.ItemName.LastIndexOf('#') + 1).Trim();
                    if (sku.Length == 4)
                    {
                        cf = new Core.DoMain.GoodsCoefficientType();
                        cf.GoodsNum = 1;
                        cf.ItemSku = sku;
                        cf.SaleSku = ogt.Sku;
                        cf.insert();
                        ogt.ItemNo = cf.ItemSku;
                        ogt.ItemNum = cf.GoodsNum * ogt.ItemNum;
                    }

                }
                ogt.insert();
            }
        }

        /// <summary>
        /// 获得Paypal账户
        /// </summary>
        private void GetPaypals()
        {
            if (paypals.Count == 0)
            {
                List<OMS.Core.DoMain.PaypalAccountType> payUsers = OMS.Core.DoMain.PaypalAccountType.findAll();
                foreach (OMS.Core.DoMain.PaypalAccountType payUser in payUsers)
                {
                    IAPIProfile paypal = AppSettingHelper.CreateAPIProfile(payUser.APIKEY, payUser.APIPWD, payUser.ApiToken);
                    paypals.Add(paypal);
                }
            }
        }
        List<IAPIProfile> paypals = new List<IAPIProfile>();

        public void GetOrderByFile(string fileName, Core.DoMain.SaleAccountType account)
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
