using Movies.Client.Models;

namespace Movies.Client.ApiServices;

public class MovieApiService : IMovieApiService
{
    public Task<Movie> CreateMovie()
    {
        throw new NotImplementedException();
    }

    public Task<Movie> DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> GetMovie(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        var movieList = new List<Movie>();
        movieList.Add(new Movie
        {
            Id = 1,
            Genre = "Comics",
            Title = "End Game",
            Rating =  "8.6",
            ImageUrl = "images/src",
            ReleaseDate = DateTime.Now,
            Owner = "swn"
        });
        return await Task.FromResult(movieList);

    }

    public Task<Movie> UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }
}