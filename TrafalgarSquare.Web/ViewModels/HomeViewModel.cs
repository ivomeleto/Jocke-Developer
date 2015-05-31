namespace TrafalgarSquare.Web.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<HomePostViewModel> LatestPostsByCategory { get; set; }

        public IEnumerable<TopPostViewModel> TopJokes { get; set; }
    }
}