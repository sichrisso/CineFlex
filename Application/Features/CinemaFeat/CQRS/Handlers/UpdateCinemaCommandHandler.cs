using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Profiles.Mappings;
using Application.Features.CinemaFeat.CQRS.Commands;
using Application.Features.CinemaFeat.DTOs;

namespace Application.Features.CinemaFeat.CQRS.Handlers;

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, ErrorOr<CinemaDto>>
{
    private readonly SocialDbContext _dbContext;
    
    public UpdateCinemaCommandHandler(SocialDbContext dbContext)
    {
        _dbContext = dbContext;   
    }
    
    public async Task<ErrorOr<CinemaDto>> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var (id, name, location, phoneNo) = request.UpdateCinemaDto;
        
        var existingCinema = await _dbContext.Cinemas.FirstOrDefaultAsync(Cinema => Cinema.Id == id, cancellationToken);
        
        if (existingCinema == null) return Error.NotFound("Cinema not found");
        
        existingCinema.Name = name;
        existingCinema.Location = location;
        existingCinema.PhoneNo = phoneNo;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return CinemaMapper.CinemaToCinemaDto(existingCinema);
    }
}