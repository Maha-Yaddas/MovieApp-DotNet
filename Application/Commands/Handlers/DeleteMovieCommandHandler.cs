using Application.Commands.Commands;
using Domain.Movie.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            await _movieRepository.DeleteMovie(request.Id);
            return Unit.Value;
        }
    }
}
