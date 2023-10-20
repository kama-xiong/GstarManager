using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace GstarManager.Models
{
    public class Country
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        [SugarColumn(Length =20,IsNullable =true)]
        public string CountryCode { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string CountryNameZh { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]        
        public string CountryNameEn { get; set; }
        
    }
}
