using MediatR;
using ErrorOr;
using Persistence;
using Application.Profiles.Mappings;
using Application.Features.CinemaFeat.CQRS.Commands;
using Application.Features.CinemaFeat.DTOs;
using Domain.Entities;

namespace Application.Features.CinemaFeat.CQRS.Handlers;

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, ErrorOr<CinemaDto>>
{
    private readonly SocialDbContext _dbContext;
    
    public CreateCinemaCommandHandler(SocialDbContext dbContext)
    {
        _dbContext = dbContext;   
    }
    
    public async Task<ErrorOr<CinemaDto>> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var (name, location, phoneNo) = request.CreateCinemaDto;
        
        var cinema = new Cinema
        {
            Name = name,
            Location = location,
            PhoneNo = phoneNo
        };
        
        var result = await _dbContext.Cinemas.AddAsync(cinema, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return CinemaMapper.CinemaToCinemaDto(result.Entity);
    }
}