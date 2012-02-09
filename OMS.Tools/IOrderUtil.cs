using System;
using System.Collections.Generic;
using System.Text;

using OMS.Core.DoMain;

namespace OMS.Tools
{
    public interface IOrderUtil
    {
        void GetOrderByAPI(SaleAccountType account, DateTime beginDate, DateTime endDate);

        void GetOrderByFile(string fileName, SaleAccountType account);

        void SetShip();

        void GetEbayStore(SaleAccountType account);

        int GetOneOrderByAPI(SaleAccountType account, string orderId);


    }
}
