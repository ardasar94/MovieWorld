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
            movie.FavoritesCount = user.Favorites.Count == 0 ? 1 : user.Favorites.Max(x=> x.FavoritesCount) + 1;
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
            movie.FavoritesCount = null;
            user.Favorites.Remove(movie);
            db.SaveChanges();
            return Json(new { success = true });
        }

        [Authorize]
        public ActionResult Favorites()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(user.Favorites.OrderBy(x => x.FavoritesCount).ToList());
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateStatusOrder(List<Movie> model)
        {
            //Update code to update Orderno     
            foreach (var item in model)
            {
                var status = db.Movies.Where(x => x.Id == item.Id).FirstOrDefault();
                if (status != null)
                {
                    status.FavoritesCount = item.FavoritesCount;
                }
                db.SaveChanges();
            }
            return Json(new { success = true });
        }


        [HttpPost]
        [Authorize]
        public ActionResult IsWatched(Movie movie)
        {
            var myMovie = db.Movies.Find(movie.Id);
            myMovie.IsWatched = movie.IsWatched;
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}