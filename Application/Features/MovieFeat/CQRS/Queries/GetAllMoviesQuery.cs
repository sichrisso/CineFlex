using Application.Common;
using MediatR;
using ErrorOr;
using Application.Features.MovieFeat.DTOs;

namespace Application.Features.MovieFeat.CQRS.Queries;

public record GetAllMoviesQuery (
    int PageNumber, 
    int PageSize
): IRequest<ErrorOr<PaginatedList<MovieDto>>>;