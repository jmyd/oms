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
                //导入订单

            }
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
