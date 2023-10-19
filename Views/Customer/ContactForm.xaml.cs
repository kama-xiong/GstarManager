using GstarManager.Models;
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

namespace GstarManager.Views.Customer
{
    /// <summary>
    /// ContactForm.xaml 的交互逻辑
    /// </summary>
    public partial class ContactForm : Window
    {
        string curPhotoUrl = null;
        public ContactForm()
        {
            InitializeComponent();
        }
        private Models.Contact getData()
        {
            var c=new Models.Contact();
            c.C_Name = ContactName.Text.Trim();
            c.C_Sex = ContactSex.Text.Trim();
            c.C_Birthday = BirthDay.SelectedDate.Value;
            c.C_Tel=ContactTel.Text.Trim();
            c.C_Email=ContactEmail.Text.Trim();
            c.C_Ime=ContactIme.Text.Trim();
            c.C_Hobby = getRichTextContent(ContactHobby);
            c.C_Remark = getRichTextContent(ContactRemark);
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

        }
        private void setData(Contact contact)
        {
            ContactName.Text = contact.C_Name;
            ContactSex.Text = contact.C_Sex;
            BirthDay.Text = contact.C_Birthday.ToString();
            ContactTel.Text = contact.C_Tel;
            ContactEmail.Text = contact.C_Email;
            ContactIme.Text = contact.C_Ime;
            setRichTextContent(ContactHobby, contact.C_Hobby);
            setRichTextContent(ContactRemark, contact.C_Remark);
            loadPhoto(contact.C_Photo);

        }
        private void setMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }

        }
        private void checkData()
        {

        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
