using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Controllers
{
    public class HomeController : Controller
    {
        private Context DatabaseContext { get; set; }

        public HomeController(Context name)
        {
            DatabaseContext = name;
        }

        public IActionResult Index()
        {
            return View();

        }

        //Put the actions here that correspond to the different pages
        public IActionResult SecondPage()
        {
            return View();

        }

        [HttpGet]
        public IActionResult MovieSubmission()
        {
            ViewBag.Category = DatabaseContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieSubmission(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Add(ar);
                DatabaseContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else {
                ViewBag.Category = DatabaseContext.Categories.ToList();

                return View(ar);
            }
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = DatabaseContext.Movies
                .Include(x => x.Category)
                .ToList();
            return View(applications);

        }

        [HttpGet]
        public IActionResult Edit(int movie_id)
        {
            ViewBag.Category = DatabaseContext.Categories.ToList();

            var application = DatabaseContext.Movies.Single(x => x.Movie_id == movie_id);

            return View("MovieSubmission", application);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            DatabaseContext.Update(ar);
            DatabaseContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
         [HttpGet]
        public IActionResult Delete(int movie_id)
        {
            var application = DatabaseContext.Movies.Single(x => x.Movie_id == movie_id);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            DatabaseContext.Movies.Remove(ar);
            DatabaseContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
