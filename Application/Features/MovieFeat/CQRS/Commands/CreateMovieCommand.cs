using MediatR;
using ErrorOr;
using Application.Features.MovieFeat.DTOs;


namespace Application.Features.MovieFeat.CQRS.Commands;

public record CreateMovieCommand(CreateMovieDto CreateMovieDto) : IRequest<ErrorOr<MovieDto>>;