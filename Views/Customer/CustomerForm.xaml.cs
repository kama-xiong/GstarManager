﻿using System;
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
using System.Windows.Shapes;
using GstarManager.Controllers;
using GstarManager.Models;

namespace GstarManager.Views.Customer
{
    /// <summary>
    /// CustomerForm.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerForm : Window
    {
        //public int curCustomerId = 0;
        public CustomerForm()
        {
            InitializeComponent();
            InitialCountry("zh");
            
        }
        private void InitialCountry(string lanaguage)
        {
            var r = new Repository<Country>();
            var list = r.GetList(); 
            foreach (var item in list)
            {
                var comboItem = new ComboBoxItem();
                switch (lanaguage.ToLower())
                {
                    case "zh":
                        comboItem.Content = item.CountryNameZh;
                        break;
                    case "en":
                        comboItem.Content = item.CountryNameEn;
                        break;
                }                                     
                comboItem.Tag = item.CountryCode;
                Country.Items.Add(comboItem);
            }
            if(Country.Items.Count > 0)
            {
                Country.SelectedIndex = 0;
            }
        }
            
        
        public Models.Customer GetData()
        {
            var c = new Models.Customer();
            c.Type = type.Text.Trim();

            c.Code = Code.Text.Trim();
            c.Name = CName.Text.Trim();
            c.Tel = Tel.Text.Trim();
            c.Fax = Fax.Text.Trim();
            c.Email = Email.Text.Trim();
            c.Address = Address.Text.Trim();
            c.City = City.Text;
            c.Province = Province.Text.Trim();
            //var currentitem = Combo_lookFor.SelectedItem as ComboBoxItem;
            var curCountryItem = type.SelectedItem as ComboBoxItem;
            c.Country = curCountryItem.Content.ToString();
            c.Country = Country.Text.Trim();
            c.Postcode = Postcode.Text.Trim();
            c.MainContact = MainContact.Text.Trim();
            c.Phone = Phone.Text.Trim();
            c.WebSite = WebSite.Text.Trim();
            c.PublicBankName_1 = PublicBankName1.Text.Trim();
            c.PublicBankName_2 = PublicBankName2.Text.Trim();
            c.PublicBankCode_1 = PublicBankCode1.Text.Trim();
            c.PublicBankCode_2 = PublicBankCode2.Text.Trim();
            c.PrivateBankName_1 = PrivateBankName1.Text.Trim();
            c.PrivateBankName_2 = PrivateBankName2.Text.Trim();
            c.PrivateBankCode_1 = PrivateBankCode1.Text.Trim();
            c.PrivateBankCode_2 = PrivateBankCode2.Text.Trim();
            c.BusinessCode = BusinessCode.Text.Trim();
            c.Tax = Tax.Text.Trim();
            return c;
        }
        public void SetData(Models.Customer c)            
        {
            //curCustomerId = c.Id;
            type.Text = c.Type;
            Code.Text = c.Code;
            CName.Text = c.Name;
            Tel.Text = c.Tel;
            Fax.Text = c.Fax;
            Email.Text = c.Email;
            Address.Text = c.Address;
            City.Text = c.City;
            Province.Text = c.Province;
            Country.Text = c.Country;
            Postcode.Text = c.Postcode;
            MainContact.Text = c.MainContact;
            Phone.Text = c.Phone;
            WebSite.Text = c.WebSite;
            BusinessCode.Text = c.BusinessCode;
            PublicBankName1.Text = c.PublicBankName_1;
            PublicBankName2.Text = c.PublicBankName_2;
            PublicBankCode1.Text = c.PublicBankCode_1;
            PublicBankCode2.Text = c.PublicBankCode_2;
            PrivateBankName1.Text = c.PrivateBankName_1;
            PrivateBankName2.Text = c.PrivateBankName_2;
            PrivateBankCode1.Text = c.PrivateBankCode_1;
            PrivateBankCode2.Text = c.PrivateBankCode_2;
            Tax.Text = c.Tax;
            dataGridContacts.ItemsSource = null;
            dataGridContacts.ItemsSource = c.Contacts;
        }
        public bool checkData()
        {
            var result = true;
            if (Code.Text.Trim().Length == 0)
            {
                Code.Background = Brushes.Pink;
                result = false;
            }
            if (CName.Text.Trim().Length == 0)
            {
                CName.Background = Brushes.Pink;
                result = false;
            }
            return result;

        }
        /// <summary>
        /// 0 retrieve  1: create  2 Update 
        /// </summary>
        /// <param name="mode"></param>
        public void setMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    Confirm.Visibility = Visibility.Hidden;                    
                    this.Title = "客户资料";
                    break;
                case 1:
                    this.Title = "新增客户资料";

                    break;
                case 2:
                    this.Title = "修改客户资料";
                    break;

            }
        }

        private void OnConfirm(object sender, RoutedEventArgs e)
        {
            if (checkData() == true)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("请将数据填写完全.");
            }

        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void dataGridContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var item = grid.SelectedItem as Models.Contact;

            if (item != null)
            {
                var form = new ContactForm();
                var ctr = new ContactController();
                var contact = ctr.GetById(item.C_Id);
                form.setData(contact);
                form.setMode(0);
                form.ShowDialog();
                
            }
        }
       


    }
}
