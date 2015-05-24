namespace TrafalgarSquare.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HomeViewModel
    {
        public IEnumerable<HomePostViewModel> LatestPostsByCategory { get; set; }

        public IEnumerable<TopPostViewModel> TopJokes { get; set; }
    }
}