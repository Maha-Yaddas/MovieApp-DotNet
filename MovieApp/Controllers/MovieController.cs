using Application.Commands.Commands;
using Application.Queries.Queries;
using Domain.Movie.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace MovieApp.Controllers
{

    [ApiController]
    [Route("Api")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator) 
        {
              _mediator = mediator;
        }

        [HttpGet("GetAllMovies")]
        public async Task<List<MovieModel>> GetMovies()
        {
            return await _mediator.Send(new GetAllMoviesQuery());

        }

        [HttpGet("GetById")]
        public async Task<MovieModel> GetMovies(int id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(id));
        }

        [HttpPost("AddViaId")]
        public async Task<MovieModel> Post(MovieModel movieModel)
        {
            return await _mediator.Send(new AddMovieCommand(movieModel));

        }

        [HttpPut("updateViaId")]
        public async Task<IActionResult> Update(int id, MovieModel movieModel)
        {
            var command = new UpdateMovieCommand(id, movieModel);
            var updatedMovie = await _mediator.Send(command);

            if (updatedMovie == null)
            {
                return NotFound(); //  si le film à mettre à jour n'existe pas
            }

            return Ok(updatedMovie); // Renvoie le film mis à jour 
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand(id);
            var result = await _mediator.Send(command);

            return Ok("Supprimé avec succès");

            //return NoContent(); 

        }
    }
}
