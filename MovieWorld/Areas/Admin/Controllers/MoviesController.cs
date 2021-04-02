using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWorld.Areas.Admin.Controllers
{
    public class MoviesController : BaseController
    {
        // GET: Admin/Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
    }
}