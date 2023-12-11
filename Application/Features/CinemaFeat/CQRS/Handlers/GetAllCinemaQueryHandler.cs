using Application.Common;
using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Profiles.Mappings;
using Application.Features.CinemaFeat.Queries;
using Application.Features.CinemaFeat.DTOs;

namespace Application.Features.CinemaFeat.CQRS.Handlers;

public class GetAllCinemasQueryHandler : IRequestHandler<GetAllCinemasQuery, ErrorOr<PaginatedList<CinemaDto>>>
{
    private readonly SocialDbContext _dbcontext;
    
    public GetAllCinemasQueryHandler(SocialDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    
    public async Task<ErrorOr<PaginatedList<CinemaDto>>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
    {
        var (pageNumber, pageSize) = request;
        var Cinemas = await _dbcontext.Cinemas
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        var CinemasDto = Cinemas.Select(CinemaMapper.CinemaToCinemaDto).ToList();
        var count = await _dbcontext.Cinemas.CountAsync(cancellationToken);

        return new PaginatedList<CinemaDto>(CinemasDto, count, pageNumber, pageSize);
    }
}