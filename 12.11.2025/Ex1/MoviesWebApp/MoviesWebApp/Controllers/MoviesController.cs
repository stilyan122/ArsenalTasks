using Microsoft.AspNetCore.Mvc;
using MoviesData;
using MoviesData.Entities;

namespace MoviesWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesDBContext context;

        public MoviesController(MoviesDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult Details(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            context.Movies.Remove(movie);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
