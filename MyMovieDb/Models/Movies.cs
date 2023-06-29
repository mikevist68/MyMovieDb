namespace MyMovieDb.Models
{
    public class Movies
    {
        public Movies() { }

        public int movie_id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public int release_year { get; set; }
        public string director { get; set; }
        
    }
}
