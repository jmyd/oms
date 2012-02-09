using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wojilu.Data;
using wojilu.ORM;
using System.Collections;

namespace OMS.Modules.User
{
    public partial class CheckDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string code = Request.QueryString["code"];
                //创建数据库
                if (DbConfig.Instance.ConnectionStringTable.ContainsKey(code))
                {

                    MappingClass ms = MappingClass.Instance;

                    foreach (DictionaryEntry entry in ms.ClassList)
                    {
                        EntityInfo entity = entry.Value as EntityInfo;
                        if (entity.Database != "userdb")
                            entity.Database = code;
                    }

                    MappingClass.createDB(ms, DatabaseType.SqlServer, DbConfig.Instance.ConnectionStringTable[code].ToString(), code);

                }
            }
        }
    }
}