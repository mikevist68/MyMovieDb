using MyMovieDb.Models;

namespace MyMovieDb
{
    public interface IMoviesRepository
    {
        public IEnumerable<Movies> GetAllMovies();
        public Movies GetMovies(int id);
        public void UpdateMovies(Movies movies);
        public void InsertMovie(Movies MovieToInsert);
        public void DeleteMovie(Movies movies);

    }
}
