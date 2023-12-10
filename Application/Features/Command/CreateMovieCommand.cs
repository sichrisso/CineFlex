using Application.Dtos;
using MediatR;
using ErrorOr;

namespace Application.Features.Command;

public record CreateMovieCommand(CreateMovieDto CreateMovieDto) : IRequest<ErrorOr<MovieDto>>;