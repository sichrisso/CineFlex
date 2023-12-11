using MediatR;
using ErrorOr;
using Application.Features.CinemaFeat.DTOs;

namespace Application.Features.CinemaFeat.CQRS.Commands;

public record UpdateCinemaCommand(UpdateCinemaDto UpdateCinemaDto) : IRequest<ErrorOr<CinemaDto>>;