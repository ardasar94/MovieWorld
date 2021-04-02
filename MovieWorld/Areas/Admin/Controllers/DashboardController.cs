using MovieWorld.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWorld.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            List<MovieYearCount> movieYearCounts = db.Movies.GroupBy(x => x.Year).Select(g => new MovieYearCount()
            {
                Year = g.Key,
                Count = g.Count()

            }).OrderBy(x => x.Year).ToList();

            DashboardViewModel vm = new DashboardViewModel()
            {
                MovieYearCounts = movieYearCounts
            };
            return View(vm);
        }
    }
}