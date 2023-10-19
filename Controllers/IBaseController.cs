using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstarManager.Controllers
{
    public interface IBaseController<T> where T : class
    {
              
        List<T> GetPageListAsc(int pagenumber,int pagesize,ref int totalcount);
        List<T> GetPageListDesc(int pagenumber,int pagesize,ref int totalcount);
        List<T> Search(string search,int pagenumber,int pagesize,ref int totalcount);
        List<T> SearchByField(string fieldname,string search, int pagenumber, int pagesize, ref int totalcount);
        int GetCount();
        List<Models.Dictionary> getDictionary(string controlName);

    }
}
