using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using GstarManager.PublicFuncs;

namespace GstarManager
{
    public class SqlClient
    {
        public static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = GetConn("E:\\Aiigistar\\Config.ini"),
            DbType = DbType.MySql,
            IsAutoCloseConnection = true
        },
           db => {
               //5.1.3.24统一了语法和SqlSugarScope一样，老版本AOP可以写外面

               db.Aop.OnLogExecuting = (sql, pars) =>
               {
                   Console.WriteLine(sql);//输出sql,查看执行sql 性能无影响


                   //获取原生SQL推荐 5.1.4.63  性能OK
                   //UtilMethods.GetNativeSql(sql,pars)

                   //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                   //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)


               };

               //注意多租户 有几个设置几个
               //db.GetConnection(i).Aop

           });        
        public static string GetConn(string strPath)
        {
            
            var server =Filefuncs.GetIniFileValue(strPath,"DataBaseSettings", "server");
            var database = Filefuncs.GetIniFileValue(strPath,"DataBaseSettings", "database");
            var port = Filefuncs.GetIniFileValue(strPath,"DataBaseSettings", "port");
            var uid = Filefuncs.GetIniFileValue(strPath,"DataBaseSettings", "uid");
            var pwd = Filefuncs.GetIniFileValue(strPath,"DataBaseSettings", "pwd");
            var conn = string.Format("server={0};database={1};uid={2};pwd={3};Port={4}", server, database, uid, pwd,port);            
            return conn;
        }

    }
}
