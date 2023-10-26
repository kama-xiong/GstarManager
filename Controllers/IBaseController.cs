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
              
        List<T> GetPageList(int pagenumber,int pagesize,ref int totalcount,string sort);        
        List<T> Search(string search,int pagenumber,int pagesize,ref int totalcount,string sort);        
        List<T> SearchByField(string fieldname,string search, int pagenumber, int pagesize, ref int totalcount,string sort);        
        int GetCount();
        

    }
}
