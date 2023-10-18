using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstarManager.Controllers
{
    /// <summary>
    /// 创建仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public Repository()
        {
            //固定数据库用法
            base.Context = SqlClient.Db;

            //动态库用法一般用于维护数据库连接字符串根据用法
            //if (!SqlSugarHelper.Db.IsAnyConnection("用户读出来的数据库ConfigId")) 
            //{
            //    SqlSugarHelper.Db.AddConnection(new ConnectionConfig() { 数据库读出来信息 });
            //}
            //base.Context = SqlSugarHelper.Db.GetConnectionScope("用户读出来的数据库ConfigId");
        }
    }
    
}
