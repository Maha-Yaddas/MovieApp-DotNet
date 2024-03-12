using Domain.Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Movie.Data
{
    public interface IMovieRepository
    {
        Task<List<MovieModel>> GetMovies();
        //MovieModel AddMovie(MovieModel movie);
        Task<MovieModel> AddMovie(MovieModel movie);
        Task<MovieModel> UpdateMovie(MovieModel movie);
        Task DeleteMovie(int id);

    }
}
