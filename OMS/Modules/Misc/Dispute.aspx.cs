﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Core.DoMain;
using wojilu;
using wojilu.Data;
using wojilu.ORM;
using System.Collections;

namespace OMS.Modules.Misc
{
    public partial class Dispute : System.Web.UI.Page
    {
        private OrderType order = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDisputeApproach.Items.Add(new ListItem("","0"));
                List<DisputeApproachType> daList = DisputeApproachType.findAll();
                foreach (DisputeApproachType da in daList)
                {
                    ddlDisputeApproach.Items.Add(new ListItem(da.ApproachName, da.Id.ToString()));
                }

                List<DisputeCategoryType> dcList = DisputeCategoryType.findAll();
                foreach (DisputeCategoryType dc in dcList)
                {
                    ddlDisputeCategory.Items.Add(new ListItem(dc.CateName, dc.Id.ToString()));
                }

                ddlCurrencyType.Items.Add(new ListItem("", "0"));
                List<CurrencyType> ctList = CurrencyType.findAll();
                foreach (CurrencyType ct in ctList)
                {
                    ddlCurrencyType.Items.Add(new ListItem(ct.CurrencyCode, ct.Id.ToString()));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            order = OrderType.find(" OrderExNo = '" + txtOrderExNo.Value.Trim() + "'").first();
            if (order == null)
            {
                return;
            }
            DisputeType di = new DisputeType();
            DateTime createTime = new DateTime();
            string strCreateDate = Request.Form[txtCreateOn.ID].Trim();
            if (string.IsNullOrEmpty(strCreateDate) || !DateTime.TryParse(strCreateDate, out createTime))
            {
                return;
            }
            di.CreateOn = createTime;
            di.PlatformName = order.OrderForm;
            di.SaleAccountName = order.UserNameForm;
            di.SendOrderDate = order.AddTime;
            di.ItemNo = GetOrderItemNo(order);
            di.TrackCode = txtTrackCode.Value.Trim();
            di.TransportMode = order.TransportMode;
            di.OrderId = order.OrderExNo;
            di.OrderNo = order.OrderNo;
            double refoundAmount = 0;
            if (!string.IsNullOrEmpty(txtRefundAmount.Value) && double.TryParse(txtRefundAmount.Value, out refoundAmount))
            {
                di.RefundAmount = refoundAmount;
            }
            if (refoundAmount > 0)
            {
                di.CurrencyCode = ddlCurrencyType.SelectedItem.Text;
            }
            di.Remark = txtRemark.Value.Trim();
            DateTime approachDate = DateTime.Now;
            if (!string.IsNullOrEmpty(txtApproachOn.Value) && DateTime.TryParse(txtApproachOn.Value, out approachDate))
            {
                di.ResolutionTime = approachDate;
            }            
            di.DisputeStatus = Request.Form["state"].Trim();
            di.DisputeCategory = ddlDisputeCategory.SelectedItem.Text;
            di.DisputeSolutionType = ddlDisputeApproach.SelectedItem.Text;
            di.insert();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            order = OrderType.find(" OrderExNo = '" + txtOrderExNo.Value.Trim() + "'").first();
            if (order != null)
            {
                txtPlatformName.Value = order.OrderForm;
                txtSaleAccountName.Value = order.UserNameForm;
                txtSendOrderDate.Value = order.AddTime.ToString();
                txtItemNo.Value = GetOrderItemNo(order);
                txtTrackCode.Value = "";
                txtTransportMode.Value = order.TransportMode;
            }            
        }

        private string GetOrderItemNo(OrderType order)
        {
            string itemNo = "";
            int i = 1;
            foreach (OrderGoodsType og in order.OrderGoods)
            {
                if (order.OrderGoods.Count == 1 || order.OrderGoods.Count == i)
                {
                    itemNo += og.ItemNo;
                }
                else
                {
                    itemNo += og.ItemNo + ",";
                }
                i++;
            }
            return itemNo;            
        }
    }
}