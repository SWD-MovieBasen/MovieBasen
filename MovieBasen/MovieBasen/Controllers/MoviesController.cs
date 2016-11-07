﻿using System;
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
                // Rediger den valgte Movie
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



        //------------- Create Genre to a Movie - Start-----------------------------------------------------------------------------------------------------------------------------------------------


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


        //------------- Create Genre to a Movie - Done-----------------------------------------------------------------------------------------------------------------------------------------------




        //------------- Create Actor to a Movie - Start-----------------------------------------------------------------------------------------------------------------------------------------------


        // GET: MovieActor/Create
        public ActionResult CreateActorToMovie(int? actorID)
        {
            ViewBag.MovieID = db.Movies.Find(actorID);
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "FullName");
            return View();
        }

        // POST: MovieActor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActorToMovie(MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                db.MoviesActors.Add(movieActor);

                // Validering/Tjekker om der allerede eksister et actor til den valgte Movie 
                var movieActorValidation = db.MoviesActors.Where(s => s.MovieID == movieActor.MovieID && s.ActorID == movieActor.ActorID).FirstOrDefault();

                if (movieActorValidation == null)
                {
                    db.SaveChanges();
                    return RedirectToAction("Details/" + movieActor.MovieID);
                }
                else
                {
                    ModelState.AddModelError("", "That Actor exist already in the Movie");
                }

            }

            ViewBag.ActorID = new SelectList(db.Actors, "ID", "FullName", movieActor.ActorID);
            return View(movieActor);
        }


        //------------- Create Actor to a Movie - Done-----------------------------------------------------------------------------------------------------------------------------------------------

    }
}
