using GstarManager.Controllers;
using GstarManager.Models;
using GstarManager.Views.Customer;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GstarManager.Views.So
{
    /// <summary>
    /// CustomerManagerPage.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerManagerPage : Page
    {
        private CustomerController _control;
        private TabControl _parenttab;
        private int _totalCount = 0;
        private int _pageSize = 0;
        private int _pageNumber = 1;
        private int _totalPage = 0;
        private ICommand lookFor_Changed;
        public CustomerManagerPage(TabControl parenttab)
        {
            _control = new CustomerController();
            _parenttab = parenttab;
            InitializeComponent();            
            _pageSize = getPageSize();    
            setDataGridDataAsc();
            setPaginationControl();
            setComboLookFor();
            
        }
        private void setComboLookFor()
        {
            var items=_control.getDictionary("combo_lookfor");
            for(int i=0; i<items.Count; i++)
            {
                
                var comboBoxItem = new ComboBoxItem() { Content = items[i].FieldNameCh, Tag = items[i].FieldNameEn };
                
                Combo_lookFor.Items.Add(comboBoxItem);
                if (i == 0)
                {
                    Combo_lookFor.SelectedItem = comboBoxItem;
                }
            }
            
            
           

        }
        private void setPaginationControl()
        {
            rCurrent.Text = _pageNumber.ToString();
            _totalPage = Math.Ceiling(Convert.ToDouble(_totalCount) / Convert.ToDouble(_pageSize)).ObjToInt(); 
            rTotal.Text = _totalPage.ToString();
            rTotalListCount.Text=_totalCount.ToString();
        } 
       
        private int getPageSize()
        {

            return pageSize.Text.Trim().ObjToInt();
            
        }
       
        private void setDataGridDataAsc()
        {            
            var list = _control.GetPageListAsc(_pageNumber,_pageSize,ref _totalCount);
            rTotal.Text=_totalCount.ToString();
            rCurrent.Text = _pageNumber.ToString();
            setItemSource(list);
            
        }
        private void setDataGridDataDesc()
        {
            var list = _control.GetPageListDesc(_pageNumber, _pageSize, ref _totalCount);
            rTotal.Text = _totalCount.ToString();
            rCurrent.Text = _pageNumber.ToString();
            setItemSource(list);
        }

        private void setItemSource(List<Models.Customer> customers)
        {
            CustomerList.ItemsSource = null;
            CustomerList.ItemsSource = customers;

        }
        
        private void add(object sender, RoutedEventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog()==true)
            {
                var c = form.GetData();
                var control = new CustomerController();
                control.Create(c);
                setDataGridDataAsc();
            }
        }

       

        private void Close(object sender, RoutedEventArgs e)
        {
            _parenttab.Items.Remove(_parenttab.SelectedItem);
            _parenttab.SelectedIndex = _parenttab.Items.Count - 1;
        }

        private void OnRetrieve(object sender, RoutedEventArgs e)
        {
            var data = CustomerList.SelectedItem as Models.Customer;
            if (data != null)
            {
                var form = new CustomerForm();
                form.SetData(data);
                form.setMode(0);
                form.ShowDialog();
            }
        }
        private void ShowDetail()
        {
            var data = CustomerList.SelectedItem as Models.Customer;
            if (data != null)
            {
                var form = new CustomerForm();
                form.SetData(data);
                form.setMode(0);
                form.ShowDialog();
            }
        }

        private void CustomerList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var item=grid.SelectedItem as Models.Customer;
            if (item != null)
            {
                OnRetrieve(sender,e);
            }           
            
         
        }
        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            var item = grid.SelectedItem as Models.Customer;
            ContactList.ItemsSource = null;
            if (item.Contacts.Count != 0)
            {
                
                ContactList.ItemsSource = item.Contacts;
            }
            
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var data = CustomerList.SelectedItem as Models.Customer;
            if (data != null)
            {
                var form = new CustomerForm();
                form.SetData(data);
                form.setMode(1);
                if (form.ShowDialog() == true)
                {
                    var customer=form.GetData();
                    customer.Id = data.Id;
                    var c = new CustomerController();
                    var result=c.Update(customer);
                    if (result == false)
                    {
                        MessageBox.Show("更新客户资料出错，请通知管理员");
                        return;
                    }
                    setDataGridDataAsc();
                }
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            var data = CustomerList.SelectedItem as Models.Customer;
            if (data != null)
            {
                if(MessageBox.Show("即将删除数据，数据删除后将不可恢复！", "删除警告", MessageBoxButton.OKCancel) == MessageBoxResult.OK){
                    var c=new CustomerController();
                    if (c.Delete(data) == false){
                        MessageBox.Show("删除数据错误，请联系管理员");
                        return;
                    }
                    setDataGridDataAsc();

                }
               
            }

        }

      
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _pageNumber += 1;
            if(_pageNumber > _totalPage) 
            {                
                _pageNumber = _totalPage;
            }
            
            setPaginationControl();
            setDataGridDataAsc();
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            _pageNumber -= 1;

            if (_pageNumber <=1)            {
                
                _pageNumber = 1;

            }            
            setPaginationControl();
            setDataGridDataAsc();
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber == _totalPage){
                return;
            }
            _pageNumber = _totalPage==0?1:_totalPage;
            setPaginationControl();
            setDataGridDataAsc();
        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber == 1){
                return;
            }
            _pageNumber = 1;           
            setPaginationControl();
            setDataGridDataAsc();

        }

        

        private void Combo_lookFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_lookFor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                TextBox_mhlookFor.Clear();
                var lookfor = TextBox_lookFor.Text.Trim();
                var currentitem = Combo_lookFor.SelectedItem as ComboBoxItem;
                var fieldName = currentitem.Tag.ToString();
                var list = _control.SearchByField(fieldName, lookfor, _pageNumber, _pageSize, ref _totalCount);
                rTotal.Text = _totalCount.ToString();
                setItemSource(list);
            }
        }

        private void TextBox_mhlookFor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                TextBox_lookFor.Clear();
                var mhlook = TextBox_mhlookFor.Text.Trim();
                var list = _control.Search(mhlook, _pageNumber, _pageSize, ref _totalCount);
                rTotal.Text = _totalCount.ToString();
                setItemSource(list);
            }
            
        }

        private void OnCreateContact(object sender, RoutedEventArgs e)
        {

        }

        private void OnRetrieveContact(object sender, RoutedEventArgs e)
        {

        }

        private void OnUpdateContact(object sender, RoutedEventArgs e)
        {

        }

        private void OnDeleteContact(object sender, RoutedEventArgs e)
        {

        }
    }
}
