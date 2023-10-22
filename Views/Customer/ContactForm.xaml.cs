using GstarManager.Models;
using GstarManager.PublicFuncs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GstarManager.Views.Customer
{
    /// <summary>
    /// ContactForm.xaml 的交互逻辑
    /// </summary>
    public partial class ContactForm : Window
    {
        string curPhotoUrl = null;
        public string _object_pre = @"manager/object/contact/";
        public string _local_pre = @"\temp\contact\";
        public ContactForm()
        {
            InitializeComponent();
            
        }
        public Models.Contact getData()
        {
            var c=new Models.Contact();
            c.C_Name = ContactName.Text.Trim();
            c.C_Sex = ContactSex.Text.Trim();
            c.C_Birthday = BirthDay.SelectedDate.Value;
            c.C_Tel=ContactTel.Text.Trim();
            c.C_Email=ContactEmail.Text.Trim();
            c.C_Ime=ContactIme.Text.Trim();
            c.C_Hobby=ContactHobby.Text.Trim();
            c.C_Remark=ContactRemark.Text.Trim();
            //c.C_Hobby = getRichTextContent(ContactHobby);
            //c.C_Remark = getRichTextContent(ContactRemark);
            c.C_Photo = curPhotoUrl;
            return c;
        }
        private string getRichTextContent(RichTextBox rtb)
        {
                TextRange textRange = new TextRange(
            // TextPointer to the start of content in the RichTextBox.
            rtb.Document.ContentStart,
            // TextPointer to the end of content in the RichTextBox.
            rtb.Document.ContentEnd
        );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
        private void setRichTextContent(RichTextBox rtb, string str)
        {
            rtb.Document.Blocks.Clear();           
            Run run = new Run(str);
            Paragraph p = new Paragraph();                        
            p.Inlines.Add(run);
            rtb.Document.Blocks.Add(p);
        }
        private void loadPhoto(string photo)
        {
            var objectname = _object_pre + photo;            
            var localpath = System.IO.Directory.GetCurrentDirectory() + _local_pre;
            var locafilename = localpath + photo;
            if (Directory.Exists(localpath)==false)
            {
                Directory.CreateDirectory(localpath);
            }
            Filefuncs.DownloadFileFromOss(locafilename, objectname);
            var bitmap = new BitmapImage(new Uri(locafilename));
            ContactImage.Source = bitmap;

        }
        public void setData(Contact contact)
        {
            
            ContactName.Text = contact.C_Name;
            ContactSex.Text = contact.C_Sex;
            BirthDay.Text = contact.C_Birthday.ToString();
            ContactTel.Text = contact.C_Tel;
            ContactEmail.Text = contact.C_Email;
            ContactIme.Text = contact.C_Ime;
            ContactHobby.Text= contact.C_Hobby;
            ContactRemark.Text = contact.C_Remark;
            //setRichTextContent(ContactHobby, contact.C_Hobby);
            //setRichTextContent(ContactRemark, contact.C_Remark);
            if (contact.C_Photo != null)
            {
                loadPhoto(contact.C_Photo);
                curPhotoUrl = contact.C_Photo;
            }
            

        }
        /// <summary>
        /// 0:retrieve 1:create 2 update
        /// </summary>
        /// <param name="mode"></param>
        public void setMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    Confirm.Visibility = Visibility.Hidden;
                    this.Title = "联系人资料";
                    ContactHobby.IsReadOnly = true;
                    ContactRemark.IsReadOnly = true;
                    ContactName.IsReadOnly = true;
                    ContactEmail.IsReadOnly = true;
                    ContactSex.IsReadOnly = true;
                    ContactTel.IsReadOnly = true;
                    ContactImage.IsEnabled = true;
                    ContactIme.IsReadOnly = true;
                    LoadImage.IsEnabled = false;
                    BirthDay.IsEnabled = false;
                    break;
                case 1:
                    this.Title = "新增联系人";
                    BirthDay.SelectedDate = DateTime.Now;
                    break;
                case 2:
                    this.Title = "修改联系人";
                    break;

            }

        }
       
    private bool checkData()
        {
            bool hasNoError = true; ;
            if (BirthDay.SelectedDate== null)
            {
                BirthDay.Background = Brushes.Pink;
                hasNoError = false;
            }
            if (ContactName.Text == null)
            {
                ContactName.Background = Brushes.Pink;
                hasNoError = false;
            }
            else
            {
                if(ContactName.Text.Length == 0)
                {
                    ContactName.Background = Brushes.Pink;
                    hasNoError = false;
                }
            }
            return hasNoError;

        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "图片|*.jpg;*.jpeg;*.gif;*.bmp";
            if (openfiledialog.ShowDialog() == true)
            {
                curPhotoUrl=openfiledialog.FileName;
                var bitmap = new BitmapImage(new Uri(curPhotoUrl));
                ContactImage.Source= bitmap;
                
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (checkData() == true)
            {
                DialogResult = true;
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ContactImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                e.Handled=true;
                var localpath = System.IO.Directory.GetCurrentDirectory() + _local_pre;    
                if (System.IO.Directory.Exists(localpath))
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = localpath + curPhotoUrl;
                    if (System.Environment.Is64BitOperatingSystem)
                    {
                        process.StartInfo.Arguments = "rundll32.exe C:\\Windows\\SysWOW64\\shimgvm.dll,ImageView_FullScreen";
                    }
                    else
                    {
                        process.StartInfo.Arguments = "rundll32.exe C:\\Windows\\System32\\shimgvm.dll,ImageView_FullScreen";
                    }

                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process.Start();
                    process.Close();
                }
                
            }
        
        
        }
    }
}
