using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GstarManager.Models;

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
            throw new NotImplementedException();
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
