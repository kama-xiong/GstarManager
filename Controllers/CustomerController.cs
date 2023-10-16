﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GstarManager.Models;
using SqlSugar;

namespace GstarManager.Controllers
{
    public class CustomerController : IBaseController<Customer>
    {
                
        public Customer Create(Customer entity)
        {
            return SqlClient.Db.Insertable(entity).ExecuteReturnEntity();
        }

        public bool Delete(Customer entity)
        {
            return SqlClient.Db.Deleteable(entity).ExecuteCommandHasChange();
        }

        public Customer GetById(int id)
        {
            return SqlClient.Db.Queryable<Customer>().Where(it => it.Id == id).First();           
            
        }

        public int GetCount()
        {
            return SqlClient.Db.Queryable<Models.Customer>().Count();
        }

        public List<Dictionary> getDictionary(string controlName)
        {
            return SqlClient.Db.Queryable<Models.Dictionary>().Where(it => (it.TableName == "Customer" || it.TableName == "customer")&&it.ControlName==controlName).ToList();
        }

        public List<Customer> GetPageListAsc(int pagenumber,int pagesize,ref int totalcount)
        {
            
            return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts).ToPageList(pagenumber,pagesize,ref totalcount);
        }

        public List<Customer> GetPageListDesc(int pagenumber, int pagesize, ref int totalcount)
        {
            return SqlClient.Db.Queryable<Customer>().Includes(x=>x.Contacts).OrderBy(it=>it.Id,SqlSugar.OrderByType.Desc).ToPageList(pagenumber, pagesize, ref totalcount);
        }

        public List<Customer> Search(string search,int pagenumber,int pagesize,ref int totalcount)
        {

            return SqlClient.Db.Queryable<Customer>().Includes(x => x.Contacts)
                 .Where(it => it.Name.Contains(search) || it.Code.Contains(search) || it.WebSite.Contains(search) || it.Email.Contains(search)
                 ||it.Phone.Contains(search)||it.MainContact.Contains(search)||it.Address.Contains(search)||it.Fax.Contains(search)            )
                .ToPageList(pagenumber, pagesize, ref totalcount);
        }

        public List<Customer> SearchByField(string fieldname, string search, int pagenumber, int pagesize, ref int totalcount)
        {
            
            
            var sqlstr = string.Format("select Customer.*,Contact.* from Customer left join Contact on Id=Contact.CustomerId where {0} like '%{1}%'", fieldname, search);
            List<Customer> list = SqlClient.Db.SqlQueryable<Customer>(sqlstr).ToPageList(pagenumber, pagesize, ref totalcount);
            Console.WriteLine(sqlstr);
            return list;  
            

        }

        public bool Update(Customer entity)
        {
            return SqlClient.Db.Updateable(entity).ExecuteCommandHasChange();
        }
    }
}