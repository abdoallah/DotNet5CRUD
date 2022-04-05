using DotNetCrud.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCrud.EF.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T GetById(int id)
        {

            return _context.Set<T>().Find(id);
        }

        //return all items in selected model of <T>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
        
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
           
            return entities;
        }

        //update method
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;

        }
        //delete method
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
      
     

    }
}
