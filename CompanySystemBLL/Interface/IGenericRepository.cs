using CompanySystemDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystemBLL.Interface
{
    public interface IGenericRepository <T> 
    {
        IEnumerable<T> GetAll();

       
        T Get(int id);

        
        T Add(T entity);

      
        int Update(T entity);

       
        int Delete(T Entity);
    }
}
