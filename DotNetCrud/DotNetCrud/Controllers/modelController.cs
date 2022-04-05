using DotNetCrud.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DotNetCrud.core.Models;
using DotNetCrud.core;

namespace DotNetCrud.Controllers
{
    public class modelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public modelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
       

    }
}
