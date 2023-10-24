using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace GstarManager.Models
{
    public class Material
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true )]
        public int Id { get; set; }
        [SugarColumn(Length =10,IsNullable =true)]
        public string MType { get; set; }//成品，半成品，原材料
        [SugarColumn(Length = 20, IsNullable = true)]
        public string MCode { get; set; }
        [SugarColumn(Length = 60, IsNullable = true)]
        public string MName { get; set; }
        [SugarColumn(Length = 60, IsNullable = true)]
        public string Size { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]
        public string Unit { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Inner { get; set; }
        [SugarColumn(Length = 100, IsNullable = true)]
        public string CombMaterial { get; set; }
        [SugarColumn(Length = 60, IsNullable = true)]
        public string Color { get; set; }
        public int MouldId { get; set; }
        [Navigate(NavigateType.OneToOne,nameof(MouldId))]
        public Mould Mould { get; set; }
        [Navigate(NavigateType.OneToMany,nameof(MaterialPicture.MaterialId))]
        public List<MaterialPicture> MaterialPictures { get; set; }

    }
    public class MaterialPicture
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public bool isInner { get; set; }
        [SugarColumn(Length =100, IsNullable = true)]
        public string ImgUrl { get; set; }
        [SugarColumn(Length =20,IsNullable =true)]
        public string ImgName { get; set; }
        public int MaterialId { get; set; }
    }
    public class Mould
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]
        public string MouldBigType { get; set; }//模具大分类 如塑胶模，五金模，吸塑模
        [SugarColumn(Length = 20, IsNullable = true)]
        public string MouldNormalType { get; set; }//模具小分类：如方角盒，圆角盒等
        public int SupplierId { get; set; }
        
        [SugarColumn(Length = 40, IsNullable = true)]
        public string SupplierName { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]

        public string MouldCode { get; set; }
        [SugarColumn(Length = 30, IsNullable = true)]
        public string MouldSize { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]
        public string Length { get; set; }
        [SugarColumn(Length = 10, IsNullable = true)]
        public string Width { get; set; }
        [SugarColumn(Length = 40, IsNullable = true)]
        public string Remark { get; set; }
    }
}
