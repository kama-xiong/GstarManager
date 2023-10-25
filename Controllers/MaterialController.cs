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
            throw new NotImplementedException();
        }

        public List<Material> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            throw new NotImplementedException();
        }
        
    }
}
