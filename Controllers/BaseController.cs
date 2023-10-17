using GstarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstarManager.Controllers
{
    public class BaseController<T> : IBaseController<T> where T:class
    {
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary> getDictionary(string controlName)
        {
            throw new NotImplementedException();
        }

        public List<T> GetPageListAsc(int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }

        public List<T> GetPageListDesc(int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }

        public List<T> Search(string search, int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }

        public List<T> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
