using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWorld.ViewModels
{
    public class HomeViewModel
    {
        public List<Movie> Movies { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}