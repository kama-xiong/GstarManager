using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Aliyun.OSS;
using MySqlX.XDevAPI;
using System.Security.AccessControl;
using GstarManager.Models;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Shapes;


namespace GstarManager.PublicFuncs
{
    public static class Filefuncs
    {
        public static OssSetting _bucket = getBucket(@"E:\Aiigistar\config.ini");
        public static OssClient _client = new OssClient(_bucket.Endpoint, _bucket.AccessKeyId, _bucket.AccessKeySecret);
        [DllImport("kernel32")]// 读配置文件方法的6个参数：所在的分区（section）、 键值、     初始缺省值、   StringBuilder、  参数长度上限 、配置文件路径
        public static extern long GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]//写入配置文件方法的4个参数：  所在的分区（section）、  键值、     参数值、       配置文件路径
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);
        /*读配置文件*/
        public static string GetIniFileValue(string strPath, string section, string key)
        {
            // ▼ 获取当前程序启动目录
            //string strPath = "E:\\Aiigistar\\config.ini";
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
        public static OssSetting getBucket(string settingStrPath)
        {

            //string settingStrPath = "E:\\Aiigistar\\config.ini";
            // yourEndpoint填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
            var endpoint = GetIniFileValue(settingStrPath, "OssSetting", "endpoint");
            // 从环境变量中获取访问凭证。运行本代码示例之前，请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            var accessKeyId = GetIniFileValue(settingStrPath, "OssSetting", "accessKeyId");
            var accessKeySecret = GetIniFileValue(settingStrPath, "OssSetting", "accessKeySecret");
            // 填写Bucket名称，例如examplebucket。
            var bucketName = GetIniFileValue(settingStrPath, "OssSetting", "bucketName");
            var set = new OssSetting() { BucketName = bucketName, Endpoint = endpoint, AccessKeyId = accessKeyId, AccessKeySecret = accessKeySecret };
            return set;
        }
        /*写配置文件*/
        public static void SetIniFileValue(string strPath, string section, string key, string value)
        {
            // ▼ 获取当前程序启动目录
            // string strPath = Application.StartupPath + @"/config.ini";  这里是绝对路径
            //string strPath = "E:\\Aiigistar";
            //string strPath = "./config.ini";      //这里是相对路径，
            WritePrivateProfileString(section, key, value, strPath);
        }

        public static bool SaveFileToOss(string localFilename, string objectName)
        {
            //string settingStrPath = "E:\\Aiigistar\\config.ini";
            //// yourEndpoint填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
            //var endpoint = GetIniFileValue(settingStrPath, "OssSetting", "endpoint");
            //// 从环境变量中获取访问凭证。运行本代码示例之前，请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            //var accessKeyId = GetIniFileValue(settingStrPath, "OssSetting", "accessKeyId");
            //var accessKeySecret = GetIniFileValue(settingStrPath, "OssSetting", "accessKeySecret");
            //// 填写Bucket名称，例如examplebucket。
            //var bucketName = GetIniFileValue(settingStrPath, "OssSetting", "bucketName");
            //// 填写Object完整路径，完整路径中不能包含Bucket名称，例如exampledir/exampleobject.txt。

            //// 创建OSSClient实例。

            //var client = new OssClient(_bucket.Endpoint, _bucket.AccessKeyId, _bucket.AccessKeySecret);
            try
            {
                // 上传文件。
                _client.PutObject(_bucket.BucketName, objectName, localFilename);
                Console.WriteLine("Put object succeeded");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
                return false;
            }

        }
        public static bool DeleteFileFromOss(string objectName)
        {
            try
            {
                // 删除文件。
                _client.DeleteObject(_bucket.BucketName, objectName);
                Console.WriteLine("Delete object succeeded");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete object failed. {0}", ex.Message);
                return false;
            }
        }
        public static bool DownloadFileFromOss(string localFilename, string objectName)
        {
            //string settingStrPath = "E:\\Aiigistar\\config.ini";
            //// yourEndpoint填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
            //var endpoint = GetIniFileValue(settingStrPath, "OssSetting", "endpoint");
            //// 从环境变量中获取访问凭证。运行本代码示例之前，请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            //var accessKeyId = GetIniFileValue(settingStrPath, "OssSetting", "accessKeyId");
            //var accessKeySecret = GetIniFileValue(settingStrPath, "OssSetting", "accessKeySecret");
            //// 填写Bucket名称，例如examplebucket。
            //var bucketName = GetIniFileValue(settingStrPath, "OssSetting", "bucketName");
            //// 填写Object完整路径，完整路径中不能包含Bucket名称，例如exampledir/exampleobject.txt。

            // 创建OSSClient实例。
            var client = new OssClient(_bucket.Endpoint, _bucket.AccessKeyId, _bucket.AccessKeySecret);
            try
            {
                // 下载文件到流。OssObject包含了文件的各种信息，如文件所在的存储空间、文件名、元信息以及一个输入流。
                var obj = client.GetObject(_bucket.BucketName, objectName);
                using (var requestStream = obj.Content)
                {
                    byte[] buf = new byte[1024];
                    var fs = File.Open(localFilename, FileMode.OpenOrCreate);
                    var len = 0;
                    // 通过输入流将文件的内容读取到文件或者内存中。
                    while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                    {
                        fs.Write(buf, 0, len);
                    }
                    fs.Close();
                }
                Console.WriteLine("Get object succeeded");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get object failed. {0}", ex.Message);
                return false;
            }

        }
        public static BitmapImage GetImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            if (File.Exists(imagePath))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                using (Stream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                {
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }
            return bitmap;
        }

       

    }
}