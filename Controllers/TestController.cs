using GstarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstarManager.Controllers
{
    public  class TestController<T>:Repository<T> where T : class,new()
    {
        

        public TestController()
        {
            
        }

        public async Task<bool> Create(T entity)
        {
           await base.InsertAsync(entity);
            return true;
        }
    }
}
