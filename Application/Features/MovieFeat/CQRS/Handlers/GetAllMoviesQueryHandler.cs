using Application.Common;
using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Profiles.Mappings;
using Application.Features.MovieFeat.CQRS.Queries;
using Application.Features.MovieFeat.DTOs;

namespace Application.Features.MovieFeat.CQRS.Handlers;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ErrorOr<PaginatedList<MovieDto>>>
{
    private readonly SocialDbContext _dbcontext;
    
    public GetAllMoviesQueryHandler(SocialDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    
    public async Task<ErrorOr<PaginatedList<MovieDto>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var (pageNumber, pageSize) = request;
        var movies = await _dbcontext.Movies
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        var moviesDto = movies.Select(MovieMapper.MovieToMovieDto).ToList();
        var count = await _dbcontext.Movies.CountAsync(cancellationToken);

        return new PaginatedList<MovieDto>(moviesDto, count, pageNumber, pageSize);
    }
}



