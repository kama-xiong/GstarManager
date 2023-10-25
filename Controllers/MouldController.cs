using GstarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GstarManager.Models;

namespace GstarManager.Controllers
{
    public class MouldController : Repository<Mould>, IBaseController<Mould>
    {
        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary> getDictionary(string controlName)
        {
            throw new NotImplementedException();
        }

        public List<Mould> GetPageList(int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            throw new NotImplementedException();
        }

        public List<Mould> Search(string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            throw new NotImplementedException();
        }

        public List<Mould> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            throw new NotImplementedException();
        }
        
    }
}
