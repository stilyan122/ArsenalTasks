using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ViewModels;
using System.Diagnostics;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVm
            {
                FeaturedMovies = await _db.Movies
                    .OrderByDescending(m => m.Year)
                    .Take(6)
                    .ToListAsync(),

                UpcomingScreenings = await _db.Screenings
                    .Include(s => s.Movie)
                    .Where(s => s.StartTime >= DateTime.UtcNow.AddHours(-2))
                    .OrderBy(s => s.StartTime)
                    .Take(15)
                    .ToListAsync()
            };
            return View(vm);
        }
    }
}
