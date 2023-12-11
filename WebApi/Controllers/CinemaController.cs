using Application.Features.CinemaFeat.DTOs;
using Application.Features.CinemaFeat.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappings;

namespace WebApi.Controllers;

[Route("/api/v1/Cinemas")]
public class CinemaController: ApiController
{
    private readonly ISender _sender;
    
    public CinemaController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCinemas(CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _sender.Send(new GetAllCinemasQuery(pageNumber, pageSize), cancellationToken);
        return result.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCinema([FromBody] CreateCinemaDto createCinemaDto, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(CinemaMapper.CreateCinemaDtoToCreateCinemaCommand(createCinemaDto),
            cancellationToken);
        return result.Match(Ok, Problem);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCinema([FromBody] UpdateCinemaDto updateCinemaDto, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(CinemaMapper.UpdateCinemaDtoToUpdateCinemaCommand(updateCinemaDto),
            cancellationToken);
        return result.Match(Ok, Problem);
    }
}