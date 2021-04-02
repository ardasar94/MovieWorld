using Microsoft.AspNet.Identity;
using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWorld.Controllers
{
    public class MoviesController : BaseController
    {
        [HttpPost]
        [Authorize]
        public ActionResult AddToFavorites(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null) return HttpNotFound();
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            user.Favorites.Add(movie);
            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveFromFavorites(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null) return HttpNotFound();
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            user.Favorites.Remove(movie);
            db.SaveChanges();
            return Json(new { success = true });
        }

        [Authorize]
        public ActionResult Favorites()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(user.Favorites.ToList());
        }
    }
}