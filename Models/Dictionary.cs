using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace GstarManager.Models
{
    public class Dictionary
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        [SugarColumn(Length =20,IsNullable =true)]        
        public string TableName { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]        
        public string ControlName { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string FieldNameCh { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string FieldNameEn { get; set; }

    }
}
