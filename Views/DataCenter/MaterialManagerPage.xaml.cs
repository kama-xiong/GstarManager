﻿using GstarManager.Controllers;
using GstarManager.Models;
using SqlSugar.Extensions;
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
        private Material curMaterial = null;
        private MaterialController _control=new MaterialController();
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
            _pageSize = pageSize.Text.Trim().ObjToInt();
            setDataGridData(curSearchType);            
            MaterialDataList.LoadingRow += (se, e) => e.Row.Header = e.Row.GetIndex() + 1 + (_pageNumber - 1) * _pageSize;

        }
        /// <summary>
        /// 重新计算分页控件并更新
        /// </summary>
        private void setPaginationControl()
        {
            rCurrent.Text = _pageNumber.ToString();
            _totalPage = Math.Ceiling(Convert.ToDouble(_totalCount) / Convert.ToDouble(_pageSize)).ObjToInt();
            rTotal.Text = _totalPage.ToString();
            rTotalListCount.Text = _totalCount.ToString();
        }
        /// <summary>
        /// 获得当前分页大小
        /// </summary>
        /// <returns></returns>       


        /// <summary>
        /// 按增序设置当前物料清单数据 MaterialDataList
        /// </summary>        
        private void setDataGridData(int searchType)
        {
            var c = new MaterialController();
            var list = new List<Models.Material>();
            switch (searchType)
            {
                case 0:
                    list = c.GetPageList(_pageNumber, _pageSize, ref _totalCount, "desc");
                    break;
                case 1:
                    var mhlook = TextBox_mhlookFor.Text.Trim();
                    list = c.Search(mhlook, _pageNumber, _pageSize, ref _totalCount, "desc");

                    break;
                case 2:
                    var lookfor = TextBox_lookFor.Text.Trim();
                    var currentitem = Combo_lookFor.SelectedItem as ComboBoxItem;
                    var fieldName = currentitem.Tag.ToString();
                    list = c.SearchByField(fieldName, lookfor, _pageNumber, _pageSize, ref _totalCount, "desc");
                    break;
            }
            setItemSource(list);
            setPaginationControl();
            MaterialDataList.SelectedIndex = 0;
            MaterialDataList.Focus();

        }
        /// <summary>
        /// 依据数据设置DataGrid数据
        /// </summary>
        /// <param name="customers"></param>

        private void setItemSource(List<Models.Material> materials)
        {
            MaterialDataList.ItemsSource = null;
            MaterialDataList.ItemsSource = materials;

        }


        private void OnCreate(object sender, RoutedEventArgs e)
        {
            var form = new MaterialForm();
            form.SetMode(1);
            if (form.ShowDialog() == true)
            {
                var m = form.GetData();
                var ctrl = new MaterialController();
                ctrl.Insert(m);

            }
        }

        private void OnRetrieve(object sender, RoutedEventArgs e)
        {
            var form = new MaterialForm();
            form.SetMode(0);
            form.ShowDialog();

        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var form = new MaterialForm();
            if (curMaterial == null){
                MessageBox.Show("请选择需要修改的物料", "提示", MessageBoxButton.OKCancel);
                return;
            }
            form.SetData(curMaterial);
            form.SetMode(2);
            if (form.ShowDialog() == true)
            {
                var newmaterial=form.GetData();
                var ctrl=new MaterialController();
                ctrl.Update(newmaterial);

            }

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
