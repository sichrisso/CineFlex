using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Profiles.Mappings;
using Application.Features.MovieFeat.DTOs;
using Application.Features.MovieFeat.CQRS.Commands;

namespace Application.Features.MovieFeat.CQRS.Handlers;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, ErrorOr<MovieDto>>
{
    private readonly SocialDbContext _dbContext;
    
    public UpdateMovieCommandHandler(SocialDbContext dbContext)
    {
        _dbContext = dbContext;   
    }
    
    public async Task<ErrorOr<MovieDto>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var (id, title, genre, releaseYear) = request.UpdateMovieDto;
        
        var existingMovie = await _dbContext.Movies.FirstOrDefaultAsync(movie => movie.Id == id, cancellationToken);
        
        if (existingMovie == null) return Error.NotFound("Movie not found");
        
        existingMovie.Title = title;
        existingMovie.Genre = genre;
        existingMovie.ReleaseYear = releaseYear;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return MovieMapper.MovieToMovieDto(existingMovie);
    }
}