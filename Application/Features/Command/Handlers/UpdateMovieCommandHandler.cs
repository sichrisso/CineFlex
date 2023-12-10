using Application.Dtos;
using Application.Mappings;
using MediatR;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Command.Handlers;

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