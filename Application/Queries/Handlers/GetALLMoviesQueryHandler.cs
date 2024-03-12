using Application.Queries.Queries;
using AutoMapper;
using Domain.Movie.Data;
using Domain.Movie.Models;
using Infrastructure.Movie.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetALLMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieModel>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetALLMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper) 
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<List<MovieModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {

            var movies = await _movieRepository.GetMovies(); // Attendre la fin de la tâche
            var movieModels = _mapper.Map<List<MovieModel>>(movies);
            return movieModels;
            // return Task.FromResult(_movieRepository.GetMovies());
        }
    }
}
