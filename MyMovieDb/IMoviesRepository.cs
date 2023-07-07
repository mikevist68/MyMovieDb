using Google.Protobuf.WellKnownTypes;
using MyMovieDb.Models;

namespace MyMovieDb
{   //this is an interface(interface is a blueprint that a class must meet)
    public interface IMoviesRepository
    {   //this a method that returns a collection of all movies.It does not take any parameters.
        public IEnumerable<Movies> GetAllMovies();
        //a method that retrieves a specific movie based on the provided id parameter.
        public Movies GetMovies(int id);
        //this is a method that updates an existing movie.It takes a Movies object as a parameter, representing the updated movie.
        public void UpdateMovies(Movies movies);
        // this is a method that inserts a new movie.It takes a Movies object as a parameter, representing the movie to be inserted.
        public void InsertMovie(Movies MovieToInsert);
        // this is a method that deletes a movie (movies is the object as a pararmeter) which will represent a movie to be deleted 
        public void DeleteMovie(Movies movies);

    }
}

//this IMovieRepository interface declares several methods related to movie data 
//operations. It serves as a contract that defines the
//required behavior for interacting with movie data in 
//a repository.