using MovieApp.Data.Models;

namespace MovieApp.ViewModels
{
    public class HomeVm
    {
        public List<Movie> FeaturedMovies { get; set; } = new();
        public List<Screening> UpcomingScreenings { get; set; } = new();
    }
}
