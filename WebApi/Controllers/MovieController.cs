using Application.Features.MovieFeat.CQRS.Queries;
using Application.Features.MovieFeat.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappings;

namespace WebApi.Controllers;

[Route("/api/v1/movies")]
public class MovieController: ApiController
{
    private readonly ISender _sender;
    
    public MovieController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMovies(CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _sender.Send(new GetAllMoviesQuery(pageNumber, pageSize), cancellationToken);
        return result.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto createMovieDto, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(MovieMapper.CreateMovieDtoToCreateMovieCommand(createMovieDto),
            cancellationToken);
        return result.Match(Ok, Problem);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDto updateMovieDto, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(MovieMapper.UpdateMovieDtoToUpdateMovieCommand(updateMovieDto),
            cancellationToken);
        return result.Match(Ok, Problem);
    }
}