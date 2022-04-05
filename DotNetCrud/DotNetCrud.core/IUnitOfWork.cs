using DotNetCrud.core.Interfaces;
using DotNetCrud.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCrud.core
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Genre> Genres { get; }
        IBaseRepository<Movie> Movies { get; }
        

        int Complete();
    }
    
}
