using Application.Commands.Commands;
using Domain.Movie.Data;
using Domain.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Commands.Handlers
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, MovieModel>
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public AddMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<MovieModel>(request.model);
            var addedMovie = await _movieRepository.AddMovie(movie);
            return _mapper.Map<MovieModel>(addedMovie);
           // return Task.FromResult(_movieRepository.AddMovie(request.model));
        }
    }
    
}
