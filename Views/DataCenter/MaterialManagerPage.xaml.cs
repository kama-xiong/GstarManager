using GstarManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GstarManager.Views.DataCenter
{
    /// <summary>
    /// MaterialManagerPage.xaml 的交互逻辑
    /// </summary>
    public partial class MaterialManagerPage : Page
    {
        private MaterialController _control;
        private TabControl _parenttab;
        private int _totalCount = 0;
        private int _pageSize = 0;
        private int _pageNumber = 1;
        private int _totalPage = 0;
        /// <summary>
        /// 0 表示显示普通清单
        /// 1 表示显示模湖查找清单
        /// 2 表示显示精确查找清单
        /// </summary>        
        private int curSearchType = 0;
        public MaterialManagerPage(TabControl parenttab)
        {
            InitializeComponent();
            _parenttab = parenttab;
        }

       
        private void OnCreate(object sender, RoutedEventArgs e)
        {

        }

        private void OnRetrieve(object sender, RoutedEventArgs e)
        {

        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {

        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {

        }

        private void OnClose(object sender, RoutedEventArgs e)
        {

        }

        private void pageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_lookFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_lookFor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBox_mhlookFor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ClearAllRequires_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnDataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void OnDataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
