using GstarManager.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GstarManager.Controllers
{
    public class ContactController : Repository<Contact>
    {

        public int GetCount()
        {

            return SqlClient.Db.Queryable<Contact>().Count();
        }

        public List<Dictionary> getDictionary(string controlName)
        {           
            throw new NotImplementedException();
        }

        public List<Contact> GetPageListAsc(int pagenumber, int pagesize, ref int totalcount)
        {
            
            return SqlClient.Db.Queryable<Contact>().ToPageList(pagenumber, pagesize, ref totalcount);
        }

        public List<Contact> GetPageListDesc(int pagenumber, int pagesize, ref int totalcount)
        {
            return SqlClient.Db.Queryable<Contact>().OrderByDescending(it=>it.C_Id).ToPageList(pagenumber, pagesize, ref totalcount);
        }

        public List<Contact> Search(string search, int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }

        public List<Contact> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }
    }
}
