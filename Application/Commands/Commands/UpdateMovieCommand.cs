using Domain.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Commands
{
    public record UpdateMovieCommand(int Id, MovieModel Model) : IRequest<MovieModel>;
}
    


        
    
  

