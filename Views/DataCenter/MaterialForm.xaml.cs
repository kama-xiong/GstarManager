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
using System.Windows.Shapes;
using GstarManager.Controllers;
using GstarManager.Models;

namespace GstarManager.Views.DataCenter
{
    /// <summary>
    /// MaterialForm.xaml 的交互逻辑
    /// </summary>
    public partial class MaterialForm : Window
    {
        private int curMaterialId = 0;        
        private int curMoldId = 0;

        public MaterialForm()
        {
            InitializeComponent();
        }
        public void SetData(Models.Material material)
        {
            MaterialType.Text = material.MType;
            MaterialCode.Text = material.MCode;
            MaterialName.Text = material.MName;
            Size.Text = material.Size;
            Inner.Text = material.Inner;
            Unit.Text = material.Unit;
            Color.Text = material.Color;
            CombMaterial.Text = material.CombMaterial;
            MoldCode.Text = material.Mould.MouldCode;
            curMaterialId=material.Id;
        }
        public Material GetData()
        {
            var material = new Material();
            material.Id = curMaterialId;
            material.MType = MaterialType.Text;
            material.MCode = MaterialCode.Text;
            material.MName = MaterialName.Text;
            material.Size=Size.Text;
            material.Inner = Inner.Text;
            material.Unit = Unit.Text;
            material.Color = Color.Text;
            material.CombMaterial = CombMaterial.Text;
            material.MouldId = curMoldId;
            return material;
        }
        private Mould GetMould(int moldid)
        {
            var ctr = new MouldController();
            return ctr.GetById(moldid);

        }
        private void LoadPictures()
        {

        }
        private bool CheckData()
        {
            bool isError = false;
            if (MaterialCode.Text.Trim().Length == 0)
            {
                isError = true;
                MaterialCode.Background = Brushes.Pink;
            }
            if(MaterialName.Text.Trim().Length == 0)
            {
                isError = true;
                MaterialName.Background = Brushes.Pink;
            }
            return isError;
        }
        /// <summary>
        /// 0:retrieve 1 create  2 update
        /// </summary>
        /// <param name="mode"></param>
        public void SetMode(int mode)
        {
            switch(mode)
            {
                case 0:
                    this.Title = "查看物料数据";
                    Confirm.Visibility = Visibility.Hidden;
                    break; 
                case 1:
                    this.Title = "新增物料数据";
                    break;
                case 2:
                    this.Title = "修改物料数据";
                    break; 
            }
        }

        private void OnConfirm(object sender, RoutedEventArgs e)
        {
            if (CheckData() == false)
            {
                DialogResult = true;
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddNewPicture(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePicture(object sender, RoutedEventArgs e)
        {

        }
    }
}
