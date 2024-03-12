using Application.Commands.Commands;
using AutoMapper;
using Domain.Movie.Data;
using Domain.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieModel>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieModel> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetMovies();
            var existingMovie = movies.FirstOrDefault(m => m.Id == request.Id);

            if (existingMovie == null)
            {
                throw new Exception("Le film à mettre à jour n'a pas été trouvé.");
            }

            // Mettez à jour les propriétés du film existant avec celles du modèle de commande
            existingMovie.Name = request.Model.Name;
            existingMovie.Description = request.Model.Description;
            // Ajoutez d'autres propriétés à mettre à jour si nécessaire

            // Mettez à jour le film dans le repository
            var updatedMovie = await _movieRepository.UpdateMovie(existingMovie);

            return _mapper.Map<MovieModel>(updatedMovie);
        }
    }
}
