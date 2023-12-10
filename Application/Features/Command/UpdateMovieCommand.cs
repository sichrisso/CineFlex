using Application.Dtos;
using MediatR;
using ErrorOr;

namespace Application.Features.Command;

public record UpdateMovieCommand(UpdateMovieDto UpdateMovieDto) : IRequest<ErrorOr<MovieDto>>;