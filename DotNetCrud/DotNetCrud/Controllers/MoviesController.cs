using DotNetCrud.core;
using DotNetCrud.core.Models;
using DotNetCrud.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNetCrud.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public IActionResult Index()
        {
            var movies =  _unitOfWork.Movies.GetAll().ToList();
            return View(movies);
        }
        public IActionResult Create()
        {
           var ViewModel = new MovieFormViewModel 
           { Genres = _unitOfWork.Genres.GetAll().OrderBy(n=>n.Name).ToList() };
        return View(ViewModel);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _unitOfWork.Genres.GetAll().OrderBy(n => n.Name).ToList();
                return View(model);

            }
            var files = Request.Form.Files;
            if (!files.Any())
            {
                model.Genres = _unitOfWork.Genres.GetAll().OrderBy(n => n.Name).ToList();
                ModelState.AddModelError("Poster", "please select Movie Poster");
                return View(model);
            }
            var poster = files.FirstOrDefault();
            var allowedExtentions = new List<string> { ".jpg", ".png" };
            if (!allowedExtentions.Contains(Path.GetExtension(poster.FileName).ToLower()))
            {
                model.Genres = _unitOfWork.Genres.GetAll().OrderBy(n => n.Name).ToList();
                ModelState.AddModelError("Poster", "only .png & .png allowed");
                return View(model);
            }
            if(poster.Length> 1048576)
            {
                model.Genres = _unitOfWork.Genres.GetAll().OrderBy(n => n.Name).ToList();
                ModelState.AddModelError("Poster", "poster size is too big ");
                return View(model);
            }
            using var datastream = new MemoryStream();
            poster.CopyTo(datastream);
            var movies = new Movie
            {
                Title = model.Title,
                GenreId = model.GenreId,
                Year = model.Year,
                Rate = model.Rate,
                StoryLine = model.StoryLine,
                Poster = datastream.ToArray()
            };
            _unitOfWork.Movies.Add(movies);
            _unitOfWork.Complete();
          
            return RedirectToAction(nameof(Index));

        }
    }
}
