using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Models;

namespace MyMovieDb.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository repo;

        public MoviesController(IMoviesRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }

        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovies(id);
            return View(movie);
        }
        public IActionResult UpdateMovie(int id)
        {
            Movies mov = repo.GetMovies(id);
            if (mov == null)
            {
                return View("MovieNotFound");
            }
            return View(mov);
        }

        public IActionResult UpdateMovieToDatabase(Movies movies)
        {
            repo.UpdateMovies(movies);

            return RedirectToAction("ViewMovie", new { id = movies.movie_id });
        }

        public IActionResult InsertMovie(Movies movies) 
        {
            return View(movies);
        }

        public IActionResult AddMovieToDb(Movies movies) 
        { 
            repo.InsertMovie(movies);
            return RedirectToAction("index");
        }

        public IActionResult DeleteMovie(Movies movies)
        {
            repo.DeleteMovie(movies);
            return RedirectToAction("Index");
        }

    }
}
