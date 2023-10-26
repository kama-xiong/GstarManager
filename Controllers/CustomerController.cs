using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using GstarManager.Models;
using SqlSugar;

namespace GstarManager.Controllers
{
    public class CustomerController : Repository<Customer>,IBaseController<Customer>
    {
                
       
        public int GetCount()
        {
            return SqlClient.Db.Queryable<Models.Customer>().Count();
        }
        public async Task<int> GetCountAsync()
        {
            return await SqlClient.Db.Queryable<Customer>().CountAsync();
        }

        
        public bool DeleteCustomerWithContacts(Customer customer)
        {
            try
            {
                SqlClient.Db.BeginTran();
                SqlClient.Db.Deleteable<Models.Contact>().Where(it => it.CustomerId == customer.Id).ExecuteCommand();
                SqlClient.Db.Deleteable(customer).ExecuteCommand();
                SqlClient.Db.CommitTran();
                return true;
                   

            }catch
            {
                SqlClient.Db.RollbackTran();
                return false;
            }
            
        }
        

        public List<Customer> GetPageList(int pagenumber,int pagesize,ref int totalcount,string sort)
        {
            if (sort.ToLower() == "desc")
            {
                return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts).OrderBy(it => it.Id, OrderByType.Desc).ToPageList(pagenumber, pagesize, ref totalcount);
            }
            else
            {
                return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts).OrderBy(it => it.Id, OrderByType.Asc).ToPageList(pagenumber, pagesize, ref totalcount);
            }        
            
        }
        public async Task<List<Customer>> GetPageListAsync(int pagenumber,int pagesize,string sort)
        {
            var list=new List<Customer>();
            if (sort.ToLower() == "desc")
            {
                list= await SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts).OrderBy(it => it.Id, OrderByType.Desc).ToPageListAsync(pagenumber, pagesize);
                
            }
            else
            {
                list= await SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts).OrderBy(it => it.Id, OrderByType.Asc).ToPageListAsync(pagenumber, pagesize);
                

            }
            return list;
        }
       

        public List<Customer> Search(string search,int pagenumber,int pagesize,ref int totalcount, string sort)
        {
            if (sort.ToLower() == "desc")
            {
                return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts)
                 .Where(it => it.Name.Contains(search) || it.Code.Contains(search) || it.WebSite.Contains(search) || it.Email.Contains(search)
                 || it.Phone.Contains(search) || it.MainContact.Contains(search) || it.Address.Contains(search) || it.Fax.Contains(search)).OrderBy(it => it.Id, OrderByType.Desc)
                .ToPageList(pagenumber, pagesize, ref totalcount);

            }
            else
            {
                return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts)
                 .Where(it => it.Name.Contains(search) || it.Code.Contains(search) || it.WebSite.Contains(search) || it.Email.Contains(search)
                 || it.Phone.Contains(search) || it.MainContact.Contains(search) || it.Address.Contains(search) || it.Fax.Contains(search)).OrderBy(it => it.Id, OrderByType.Asc)
                .ToPageList(pagenumber, pagesize, ref totalcount);
            }

            
        }
       

        public List<Customer> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount,string sort)
        {
            if (sort.ToLower() == "desc")
            {
                //var sqlstr = string.Format("select Customer.*,Contact.* from Customer left join Contact on Id=Contact.CustomerId where {0} like '%{1}%' order by id desc", fieldname, search);
                var sqlstr = string.Format("select * from Customer  where {0} like '%{1}%' order by id desc", fieldname, search);
                List<Customer> list = SqlClient.Db.SqlQueryable<Customer>(sqlstr).Includes(x=>x.Contacts).ToPageList(pagenumber, pagesize, ref totalcount);

                Console.WriteLine(sqlstr);
                return list;
            }
            else
            {
                //var sqlstr = string.Format("select Customer.*,Contact.* from Customer left join Contact on Id=Contact.CustomerId where {0} like '%{1}%' order by id desc", fieldname, search);
                var sqlstr = string.Format("select * from Customer  where {0} like '%{1}%' order by id asc", fieldname, search);
                List<Customer> list = SqlClient.Db.SqlQueryable<Customer>(sqlstr).Includes(x => x.Contacts).ToPageList(pagenumber, pagesize, ref totalcount);

                Console.WriteLine(sqlstr);
                return list;

            }
            
            
           
            

        }
       
    }
}
