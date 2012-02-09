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

namespace OMS.Modules.User
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DoPageLoad();
            }
        }
         
        private void DoPageLoad()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CompanyType ct = new CompanyType();
            ct.Code = txtCode.Value.Trim();
            if (CompanyType.count("Code='" + ct.Code + "'") > 0)
            {
                return;
            }
            ct.FullName = txtFullName.Value.Trim();
            ct.Manager = txtManager.Value;
            ct.InnerPhone = txtInnerPhone.Value.Trim();
            ct.Address = txtAddress.Value.Trim();
            ct.RechargeDate = cvt.ToTime(txtRechargeDate.Value.Trim());
            ct.RechargeDay = cvt.ToInt(txtRechargeDay.Value.Trim());
            ct.insert();
            //添加公司的全权用户admin
            SetAdmin(ct);
            //创建数据库
            if (DbConfig.Instance.ConnectionStringTable.ContainsKey(ct.Code) == false)
            {
                DbConfig.Instance.ConnectionStringTable.Add(ct.Code, (object)string.Format(DbConfig.Instance.ConnectionStringTable[DbConfig.DefaultDbName].ToString(), ct.Code));
                DbConfig.checkConnectionString(DbConfig.Instance);
                DbConfig.SaveConnectionString();
                DbConfig.Instance.DbType.Add(ct.Code, ((object)"sqlserver"));
                MappingClass ms = MappingClass.Instance;

                foreach (DictionaryEntry entry in ms.ClassList)
                {
                    EntityInfo entity = entry.Value as EntityInfo;
                    if (entity.Database != "userdb")
                        entity.Database = ct.Code;
                }

                MappingClass.createDB(ms, DatabaseType.SqlServer, DbConfig.Instance.ConnectionStringTable[ct.Code].ToString(), ct.Code);

            }

        }

        private static void SetAdmin(CompanyType ct)
        {
            UserType user = new UserType();
            user.CompanyCode = ct.Code;
            user.CompanyName = ct.FullName;
            user.Username = "admin";
            user.UserPassword = "admin888";
            user.Sex = "男";
            user.Realname = "管理员";
            user.Birthday = "";
            user.insert();
        }
    }
}