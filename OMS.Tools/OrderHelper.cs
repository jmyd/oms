using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.Tools
{
    public class OrderHelper
    {

        public static string GetSequence()
        {
            string Sequence = string.Empty;
            OMS.Core.DoMain.SerialNumberType snt = OMS.Core.DoMain.SerialNumberType.find("FullName='OrderNo'").first();
            snt.Sequence = snt.Sequence + snt.Step;
            Sequence = snt.Prefix + snt.Sequence + snt.Separator;
            snt.update();
            return Sequence;
        }

        public static string GetPackageSequence()
        {
            string Sequence = string.Empty;
            OMS.Core.DoMain.SerialNumberType snt = OMS.Core.DoMain.SerialNumberType.find("FullName='PackageNo'").first();
            snt.Sequence = snt.Sequence + snt.Step;
            Sequence = snt.Prefix + snt.Sequence + snt.Separator;
            snt.update();
            return Sequence;
        }

        public static int GetBuyer(string BuyerCode, PlatformType platformType)
        {
            OMS.Core.DoMain.BuyerType bt = OMS.Core.DoMain.BuyerType.find("BuyerCode='" + BuyerCode + "' and  PlatformCode ='" + platformType.ToString() + "'").first();
            if (bt == null)
            {
                bt = new Core.DoMain.BuyerType();
                //不存在是的操作
                bt.BuyerCode = BuyerCode;
                bt.PlatformCode = platformType.ToString();

                bt.BuyCount++;
                bt.insert();
            }
            else
            {
                bt.BuyCount++;
                bt.update();
            }
            return bt.Id;
        }
    }
}
