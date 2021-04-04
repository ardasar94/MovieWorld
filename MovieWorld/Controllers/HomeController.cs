using MovieWorld.Models;
using MovieWorld.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWorld.Controllers
{
    public class HomeController : BaseController
    {       
        public ActionResult Index(int page = 1, string search = "")
        {
            IQueryable<Movie> query = db.Movies;
            int totalItems = query.Count();
            int pageSize = 9;
            int totalPages = (int)Math.Ceiling(db.Movies.Count() / (decimal)pageSize);
            var movies = query
                .OrderByDescending(x => x.ImdbRating)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var vm = new HomeViewModel() {
                Movies = movies,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    ItemsOnPage = movies.Count,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    HasNext = page < totalPages,
                    HasPrevious = page > 1
                 }
            };
            if (search != "")
            {
                vm.Movies = vm.Movies.Where(x => 
                x.Title.ToLower().Contains(search.ToLower()) || 
                x.Genre.ToLower().Contains(search.ToLower()) || 
                x.Director.ToLower().Contains(search.ToLower()) || 
                x.Actors.ToLower().Contains(search.ToLower()) ||
                x.Language.ToLower().Contains(search.ToLower())).ToList();
            }
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}