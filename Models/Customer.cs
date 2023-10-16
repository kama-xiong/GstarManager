using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace GstarManager.Models
{
    public class Customer
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }

        [SugarColumn(Length = 16, IsNullable = true)]
        public string Type { get; set; }
        [SugarColumn(Length =10,IsNullable =true)]
        
        public string Code { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Name { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string Tel { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string Fax { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string MainContact { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string Phone { get; set; }
        [SugarColumn(Length = 160, IsNullable = true)]
        public string Address { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string City { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Province { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Country { get; set; }
        [SugarColumn(Length =10,IsNullable =true)]
        public string Postcode { get; set; }
        [SugarColumn(Length = 200, IsNullable = true)]
        
        public string WebSite { get; set; }
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Email { get; set; }

        [SugarColumn(Length = 40, IsNullable = true)]
        public string BusinessCode { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PublicBankName_1 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PublicBankCode_1 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PublicBankName_2 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PublicBankCode_2 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PrivateBankName_1 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PrivateBankCode_1 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PrivateBankName_2 { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string PrivateBankCode_2 { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Tax { get; set; }

        //[SugarColumn(IsIgnore =true)]
        [Navigate(NavigateType.OneToMany,nameof(Contact.CustomerId))]
        public List<Contact> Contacts { get; set; }
    }
    public class Contact
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int C_Id { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string C_Name { get; set; }
        
        public DateTime C_Birthday { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]
        public string C_Sex { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string C_Tel { get; set; }
        [SugarColumn(Length = 100, IsNullable = true)]

        public string C_Email { get; set; }
        [SugarColumn(Length = 100, IsNullable = true)]
        public string C_Ime { get; set; }
        [SugarColumn(Length = 200, IsNullable = true)]
        public string C_Hobby { get; set; }
        [SugarColumn(Length = 200, IsNullable = true)]
        public string C_Remark { get; set; }
        [SugarColumn(IsNullable =true,Length =100)]
        public string C_Photo { get; set; }
        [SugarColumn(IsNullable = true)]
        public int CustomerId { get; set; }
    }
}
