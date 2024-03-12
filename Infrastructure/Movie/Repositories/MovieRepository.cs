using Domain.Movie.Data;
using Domain.Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Movie.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<MovieModel> _movies = new List<MovieModel>
       {
           new MovieModel { Id=1, Name="Avatar", Description="DESC1"},
           new MovieModel { Id=2, Name="Naruto", Description="DESC2"}
       };
        public async Task<MovieModel> AddMovie(MovieModel movie)
        {
            _movies.Add(movie);
            return await  Task.FromResult(movie);
        }

        public async Task<List<MovieModel>> GetMovies()
        {
            return await Task.FromResult(_movies);
        }

        public async Task<MovieModel> UpdateMovie(MovieModel movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Description = movie.Description;
          
            }
            return await Task.FromResult(existingMovie);
        }

        public Task DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
                _movies.Remove(movie);

            return Task.CompletedTask;
        }
    }
}
