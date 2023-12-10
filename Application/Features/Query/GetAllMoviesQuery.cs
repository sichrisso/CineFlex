using Application.Common;
using Application.Dtos;
using MediatR;
using ErrorOr;

namespace Application.Features.Query;

public record GetAllMoviesQuery (
    int PageNumber, 
    int PageSize
): IRequest<ErrorOr<PaginatedList<MovieDto>>>;