using GstarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GstarManager.Controllers
{
    public class ContactController : IBaseController<Models.Contact>
    {
        public Contact Create(Contact entity)
        {
            return SqlClient.Db.Insertable(entity).ExecuteReturnEntity();
        }

        public bool Delete(Contact entity)
        {
            return SqlClient.Db.Deleteable(entity).ExecuteCommandHasChange();
        }

        public Contact GetById(int id)
        {
            return SqlClient.Db.Queryable<Contact>().Where(it => it.C_Id == id).First();
        }

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

        public bool Update(Contact entity)
        {
            return SqlClient.Db.Updateable(entity).ExecuteCommandHasChange();
        }
    }
}
