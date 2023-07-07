using Dapper;
using Microsoft.VisualBasic;
using MyMovieDb.Models;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Data;

namespace MyMovieDb
{    // class is MovieRepository it impliments the Imovierepository interface
    public class MoviesRepository : IMoviesRepository
    {   
        //this is only accessible in MoviesRepository and cant be changed once assigned 
        private readonly IDbConnection _conn;
        //this class has a constructor it takes in idbconnection parameter and assigns it to _conn idbconnection is the connection to the DB 
        public MoviesRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        // this method retrieves all movies from the database by executing a SQL query and returning the result as an IEnumerable<Movies>.
        public IEnumerable<Movies> GetAllMovies()
        {
            return _conn.Query<Movies>("SELECT * FROM Movies;");
        }
        // this method retrieves a specific movie from the db by using SQL and filtered by 'movie_id'
        public Movies GetMovies(int id)
        {
            return _conn.QuerySingle<Movies>("SELECT * FROM movies WHERE movie_id = @id", new { id = id });
        }
        // this method updates a movie in the database by executing an SQL UPDATE statement with parameterized values.
        public void UpdateMovies(Movies movie)
        {
            _conn.Execute("UPDATE movies SET title = @title, genre = @genre, release_year = @releaseYear, director = @director WHERE movie_id = @id;",
             new {  title = movie.title, genre = movie.genre, releaseYear = movie.release_year, director = movie.director, id = movie.movie_id });
        }
        // this method inserts a new movie into the database by executing an SQL INSERT statement with parameterized values.
        public void InsertMovie(Movies MovieToInsert)
        {
            _conn.Execute("INSERT INTO movies ( title, genre, release_year, director) VALUES ( @title, @genre, @release_year, @director);",
                new {  title = MovieToInsert.title, genre = MovieToInsert.genre, release_year = MovieToInsert.release_year, director = MovieToInsert.director  });
        }
        // this method deletes a movie from the database by executing an SQL DELETE statement with a parameterized WHERE clause to filter by the movie_id.
        public void DeleteMovie(Movies movies)
        {
            _conn.Execute("DELETE FROM Movies WHERE movie_id = @id;", new { id = movies.movie_id });
            
        }

    }
}
