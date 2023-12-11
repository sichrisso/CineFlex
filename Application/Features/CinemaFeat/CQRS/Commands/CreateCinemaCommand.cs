using MediatR;
using ErrorOr;
using Application.Features.CinemaFeat.DTOs;

namespace Application.Features.CinemaFeat.CQRS.Commands;

public record CreateCinemaCommand(CreateCinemaDto CreateCinemaDto) : IRequest<ErrorOr<CinemaDto>>;