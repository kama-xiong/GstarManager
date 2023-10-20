using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using GstarManager.Models;
using SqlSugar;
using GstarManager.Views.So;
using GstarManager.Controllers;

namespace GstarManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void InitialDataBase(object sender, RoutedEventArgs e)
        {
            SqlClient.Db.CodeFirst.InitTables(typeof(Customer),typeof(Contact),typeof(Dictionary));
            SqlClient.Db.CodeFirst.InitTables(typeof(Country));
        }

        private void SalesOrderManager(object sender, RoutedEventArgs e)
        {
            addTabPage("订单管理",new SoManagerPage());
        }
        private void addTabPage(string tabname,Page page)
        {
            var tabitem = new TabItem();
            tabitem.Header=tabname;
            var frame=new Frame();            
            frame.Content = page;
            tabitem.Content = frame;
            this.mainTabControl.Items.Add(tabitem);
            this.mainTabControl.SelectedItem= tabitem;
        }

        private void CustomerManager(object sender, RoutedEventArgs e)
        {
            addTabPage("客户管理",new CustomerManagerPage(mainTabControl));
        }
       
        private void CustomerContactsManager(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

       

       
    }
}
