using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieBasen.Models;

namespace MovieBasen.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                movie.SaveImage(image, Server.MapPath("~"), "/MovieImages/");

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                movie.SaveImage(image, Server.MapPath("~"), "/MovieImages/");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //------------- Create Genre to Movie - Start-----------------------------------------------------------------------------------------------------------------------------------------------


        // GET: MovieGenre/Create
        public ActionResult CreateGenretoMovie(int? movieID)
        {
            ViewBag.MovieID = db.Movies.Find(movieID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name");
            return View();
        }

        // POST: MovieGenre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenretoMovie(MovieGenre movieGenre)
        {
            if (ModelState.IsValid)
            {
                db.MoviesGenres.Add(movieGenre);

                // Validering/Tjekker om der allerede eksister et genre til den valgte Movie 
                var movieGenreValidation = db.MoviesGenres.Where(s => s.MovieID == movieGenre.MovieID && s.GenreID == movieGenre.GenreID).FirstOrDefault();

                if (movieGenreValidation == null)
                {
                    db.SaveChanges();
                    return RedirectToAction("Details/" + movieGenre.MovieID);
                }
                else
                {
                    ModelState.AddModelError("", "That Genre exist already in the Movie");
                }
             
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", movieGenre.GenreID);
            return View(movieGenre);
        }


        //------------- Create Genre to Movie - Done-----------------------------------------------------------------------------------------------------------------------------------------------

    }
}
