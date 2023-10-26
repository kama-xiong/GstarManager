using GstarManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstarManager.Seeds
{
    public static class SeedService
    {
       
        public static void setSeeds()
        {
            List<Models.Dictionary> dicts=new List<Models.Dictionary>();        

            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="物料号",FieldNameEn="MCode" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="物料名称",FieldNameEn="MName" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="规格尺寸",FieldNameEn="Size" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="内座",FieldNameEn="Inner" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="颜色",FieldNameEn="Color" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="材质",FieldNameEn="CombMaterial" });
            dicts.Add(new Models.Dictionary() {TableName="material",ControlName= "Combo_lookFor",FieldNameCh="模具编号",FieldNameEn="MouldCode" });


            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="客户号",FieldNameEn="Code" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="客户名称",FieldNameEn="Name" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="主要联系人",FieldNameEn="MainContact" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="电话",FieldNameEn="Tel" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="网址",FieldNameEn="WebSite" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="邮箱",FieldNameEn="Email" });
            dicts.Add(new Models.Dictionary() {TableName="customer",ControlName= "Combo_lookFor",FieldNameCh="国家",FieldNameEn="Country" });

            try
            {
                var re = new Repository<Models.Dictionary>();
                foreach (var dict in dicts)
                {
                   
                    re.Insert(dict);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Seed Error:"+ex.Message);
                    
            }

        }
    }
}
