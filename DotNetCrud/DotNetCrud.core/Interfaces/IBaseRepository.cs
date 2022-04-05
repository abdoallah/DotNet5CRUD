using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCrud.core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        //return all data 
        IEnumerable<T> GetAll();


        //add method
        T Add(T entity);
        //add range method
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Update(T entity);
        void Delete(T entity);
    }
}
