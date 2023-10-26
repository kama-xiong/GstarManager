using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GstarManager.Models;
using SqlSugar;

namespace GstarManager.Controllers
{
    public class MaterialController : Repository<Material>, IBaseController<Material>
    {
        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary> getDictionary(string controlName)
        {
            throw new NotImplementedException();
        }

        public List<Material> GetPageList(int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            if (sort.ToLower() == "desc")
            {
               return SqlClient.Db.Queryable<Material>().Includes(x => x.Mould)
                    .Includes(y=>y.MaterialPictures).OrderBy(it => it.Id, OrderByType.Desc).ToPageList(pagenumber, pagesize, ref totalcount);
                
            }
            else
            {
                return SqlClient.Db.Queryable<Material>().Includes(x => x.Mould)
                    .Includes(y => y.MaterialPictures).OrderBy(it => it.Id, OrderByType.Asc).ToPageList(pagenumber, pagesize, ref totalcount);
            }
        }

        public List<Material> Search(string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            if (sort.ToLower() == "desc")
            {
                return SqlClient.Db.Queryable<Material>().Includes(x => x.MaterialPictures).Includes(y=>y.Mould)
                 .Where(it => it.MCode.Contains(search) || it.MName.Contains(search) || it.Size.Contains(search) || it.Inner.Contains(search)
                 || it.CombMaterial.Contains(search) || it.Color.Contains(search) || it.Mould.MouldCode.Contains(search)).OrderBy(it => it.Id, OrderByType.Desc)
                .ToPageList(pagenumber, pagesize, ref totalcount);

            }
            else
            {
                return SqlClient.Db.Queryable<Material>().Includes(x => x.MaterialPictures).Includes(y => y.Mould)
                 .Where(it => it.MCode.Contains(search) || it.MName.Contains(search) || it.Size.Contains(search) || it.Inner.Contains(search)
                 || it.CombMaterial.Contains(search) || it.Color.Contains(search) || it.Mould.MouldCode.Contains(search)).OrderBy(it => it.Id, OrderByType.Asc)
                .ToPageList(pagenumber, pagesize, ref totalcount);
            }
        }

        public List<Material> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            if (sort.ToLower() == "desc")
            {
                
                var sqlstr = string.Format("select* from Material where {0} like '%{1}%' order by id desc", fieldname, search);
                List<Material> list = SqlClient.Db.SqlQueryable<Material>(sqlstr).Includes(x=>x.Mould).Includes(y=>y.MaterialPictures).ToPageList(pagenumber, pagesize, ref totalcount);
                Console.WriteLine(sqlstr);
                return list;
            }
            else
            {
                var sqlstr = string.Format("select* from((Material LEFT JOIN Mould ON Material.MouldId= Mould.MouldId) LEFT JOIN MaterialPicture on Material.Id = MaterialPicture.MaterialId) where {0} like '%{1}%' order by id asc", fieldname, search);
                List<Material> list = SqlClient.Db.SqlQueryable<Material>(sqlstr).ToPageList(pagenumber, pagesize, ref totalcount);
                Console.WriteLine(sqlstr);
                return list;

            }
        }
        
    }
}
