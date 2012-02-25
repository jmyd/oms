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

namespace OMS.Modules.Misc
{
    public partial class Dispute : System.Web.UI.Page
    {
        private OrderType order = null;
        private int dId = 0;
        private int oId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strDisputeId = Request.QueryString["id"];
            string strOrderId=Request.QueryString["oId"];
            
            if (!IsPostBack)
            {
                ddlDisputeApproach.Items.Add(new ListItem("",""));
                List<DisputeApproachType> daList = DisputeApproachType.findAll();
                foreach (DisputeApproachType da in daList)
                {
                    ddlDisputeApproach.Items.Add(new ListItem(da.ApproachName, da.ApproachName));
                }

                List<DisputeCategoryType> dcList = DisputeCategoryType.findAll();
                foreach (DisputeCategoryType dc in dcList)
                {
                    ddlDisputeCategory.Items.Add(new ListItem(dc.CateName, dc.CateName));
                }

                ddlCurrencyType.Items.Add(new ListItem("", ""));
                List<CurrencyType> ctList = CurrencyType.findAll();
                foreach (CurrencyType ct in ctList)
                {
                    ddlCurrencyType.Items.Add(new ListItem(ct.CurrencyCode, ct.CurrencyCode));
                }
                if (!string.IsNullOrEmpty(strDisputeId) && int.TryParse(strDisputeId, out dId))
                {
                    DisputeType dispute = DisputeType.findById(dId);
                    if (dispute != null)
                    {
                        txtPlatformName.Value = dispute.PlatformName;
                        txtSaleAccountName.Value = dispute.SaleAccountName;
                        txtSendOrderDate.Value = dispute.SendOrderDate.ToShortDateString();
                        txtItemNo.Value = dispute.ItemNo;
                        txtTrackCode.Value = dispute.TrackCode;
                        txtTransportMode.Value = dispute.TransportMode;
                        txtApproachOn.Value = dispute.ResolutionTime.ToShortDateString();
                        txtCreateOn.Value = dispute.CreateOn.ToShortDateString();
                        txtOrderExNo.Value = dispute.OrderNo;
                        txtRefundAmount.Value = dispute.RefundAmount.ToString();
                        txtRemark.Value = dispute.Remark;
                        ddlCurrencyType.SelectedValue = dispute.CurrencyCode;
                        ddlDisputeApproach.SelectedValue = dispute.DisputeSolutionType;
                        ddlDisputeCategory.SelectedValue=dispute.DisputeCategory;
                    }
                }

                if (!string.IsNullOrEmpty(strOrderId) && int.TryParse(strOrderId, out oId))
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
            di.TransportMode = txtTransportMode.Value.Trim();
            di.OrderId = order.OrderExNo;
            di.OrderNo = order.OrderNo;
            double refoundAmount = 0;
            if (!string.IsNullOrEmpty(txtRefundAmount.Value) && double.TryParse(txtRefundAmount.Value, out refoundAmount))
            {
                di.RefundAmount = refoundAmount;
            }
            if (refoundAmount > 0)
            {
                di.CurrencyCode = ddlCurrencyType.SelectedItem.Value;
            }
            di.Remark = txtRemark.Value.Trim();
            DateTime approachDate = DateTime.Now;
            if (!string.IsNullOrEmpty(txtApproachOn.Value) && DateTime.TryParse(txtApproachOn.Value, out approachDate))
            {
                di.ResolutionTime = approachDate;
            }
            di.DisputeStatus = Request.Form["state"].Trim();
            di.DisputeCategory = ddlDisputeCategory.SelectedItem.Value;
            di.DisputeSolutionType = ddlDisputeApproach.SelectedItem.Value;

            if (dId != 0 || oId != 0)
            {
                di.update();
            }
            else
            {
                di.insert();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtOrderExNo.Value.Trim()))
            {
                return;
            }
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