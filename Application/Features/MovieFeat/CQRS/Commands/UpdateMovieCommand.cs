using MediatR;
using ErrorOr;
using Application.Features.MovieFeat.DTOs;


namespace Application.Features.MovieFeat.CQRS.Commands;

public record UpdateMovieCommand(UpdateMovieDto UpdateMovieDto) : IRequest<ErrorOr<MovieDto>>;