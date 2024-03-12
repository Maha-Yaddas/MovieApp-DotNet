using Application.Queries.Queries;
using AutoMapper;
using Domain.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieModel>
    {

     
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetMovieByIdQueryHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
         
            
            var movies = await _mediator.Send(new GetAllMoviesQuery());
            var movie = movies.FirstOrDefault( u => u.Id == request.id);
            return _mapper.Map<MovieModel>(movie);
            //return movie;
        }
    }
}
