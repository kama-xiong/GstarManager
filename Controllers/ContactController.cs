using GstarManager.Models;
using GstarManager.PublicFuncs;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GstarManager.Controllers
{
    public class ContactController :Repository<Contact>, IBaseController<Contact>
    {

        public int GetCount()
        {

            return SqlClient.Db.Queryable<Contact>().Count();
        }

        public List<Dictionary> getDictionary(string controlName)
        {           
            throw new NotImplementedException();
        }

        public List<Contact> GetPageList(int pagenumber, int pagesize, ref int totalcount, string sort) 
        {
            if (sort.ToLower() == "desc")
            {
                return SqlClient.Db.Queryable<Contact>().OrderBy(it=>it.C_Id,OrderByType.Desc).ToPageList(pagenumber, pagesize, ref totalcount);
            }
            else
            {
                return SqlClient.Db.Queryable<Contact>().OrderBy(it => it.C_Id, OrderByType.Asc).ToPageList(pagenumber, pagesize, ref totalcount);
            }
            
            
        }

       

        public List<Contact> Search(string search, int pagenumber, int pagesize, ref int totalcount, string sort)
        {
            throw new NotImplementedException();
        }

        public List<Contact> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount,string sort)
        {
            throw new NotImplementedException();
        }
        public List<Contact> GetContactsByCustomerId(int customerid,string sort)
        {
            if (sort.ToLower() == "desc")
            {
                return SqlClient.Db.Queryable<Contact>().OrderBy(it=>it.C_Id,OrderByType.Desc).Where(it => it.CustomerId == customerid).ToList();
            }
            else
            {
                return SqlClient.Db.Queryable<Contact>().OrderBy(it => it.C_Id, OrderByType.Asc).Where(it => it.CustomerId == customerid).ToList();
            }
                
        }
       
    }
}
