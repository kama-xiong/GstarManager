using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace GstarManager
{
    public class SqlClient
    {
        public static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = GetConn(),
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
        [DllImport("kernel32")]// 读配置文件方法的6个参数：所在的分区（section）、 键值、     初始缺省值、   StringBuilder、  参数长度上限 、配置文件路径
        public static extern long GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]//写入配置文件方法的4个参数：  所在的分区（section）、  键值、     参数值、       配置文件路径
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);
        /*读配置文件*/
        public static string GetValue(string section, string key)
        {
            // ▼ 获取当前程序启动目录
            string strPath = "E:\\Aiigistar\\config.ini";
            //string strPath = AppDomain.CurrentDomain.BaseDirectory + @"/config.ini"; //这里是绝对路径
            //string strPath = "./config.ini";  //这里是相对路径
            if (File.Exists(strPath))  //检查是否有配置文件，并且配置文件内是否有相关数据。
            {
                StringBuilder sb = new StringBuilder(255);
                GetPrivateProfileString(section, key, "配置文件不存在，读取未成功!", sb, 255, strPath);
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        /*写配置文件*/
        public static void SetValue(string section, string key, string value)
        {
            // ▼ 获取当前程序启动目录
            // string strPath = Application.StartupPath + @"/config.ini";  这里是绝对路径
            string strPath = "E:\\Aiigistar";
            //string strPath = "./config.ini";      //这里是相对路径，
            WritePrivateProfileString(section, key, value, strPath);
        }
        public static string GetConn()
        {
            var server = GetValue("DataBaseSettings", "server");
            var database = GetValue("DataBaseSettings", "database");
            var port = GetValue("DataBaseSettings", "port");
            var uid = GetValue("DataBaseSettings", "uid");
            var pwd = GetValue("DataBaseSettings", "pwd");
            var conn = string.Format("server={0};database={1};uid={2};pwd={3};Port={4}", server, database, uid, pwd,port);
            return conn;
        }

    }
}
