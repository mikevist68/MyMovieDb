using Dapper;
using MyMovieDb.Models;
using System.Data;

namespace MyMovieDb
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IDbConnection _conn;

        public MoviesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Movies> GetAllMovies()
        {
            return _conn.Query<Movies>("SELECT * FROM Movies;");
        }
        public Movies GetMovies(int id)
        {
            return _conn.QuerySingle<Movies>("SELECT * FROM movies WHERE movie_id = @id", new { id = id });
        }
        public void UpdateMovies(Movies movie)
        {
            _conn.Execute("UPDATE movies SET title = @title, genre = @genre, release_year = @releaseYear, director = @director WHERE movie_id = @id;",
             new {  title = movie.title, genre = movie.genre, releaseYear = movie.release_year, director = movie.director, id = movie.movie_id });
        }

        public void InsertMovie(Movies MovieToInsert)
        {
            _conn.Execute("INSERT INTO movies ( title, genre, release_year, director) VALUES ( @title, @genre, @release_year, @director);",
                new {  title = MovieToInsert.title, genre = MovieToInsert.genre, release_year = MovieToInsert.release_year, director = MovieToInsert.director  });
        }

        public void DeleteMovie(Movies movies)
        {
            _conn.Execute("DELETE FROM Movies WHERE movie_id = @id;", new { id = movies.movie_id });
            
        }

    }
}
