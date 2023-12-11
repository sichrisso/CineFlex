using Application.Common;
using MediatR;
using ErrorOr;
using Application.Features.CinemaFeat.DTOs;

namespace Application.Features.CinemaFeat.Queries;

public record GetAllCinemasQuery (
    int PageNumber, 
    int PageSize
): IRequest<ErrorOr<PaginatedList<CinemaDto>>>;