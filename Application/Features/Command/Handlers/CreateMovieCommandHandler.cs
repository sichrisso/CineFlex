using Application.Dtos;
using Application.Mappings;
using Domain.Entites;
using MediatR;
using ErrorOr;
using Persistence;

namespace Application.Features.Command.Handlers;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, ErrorOr<MovieDto>>
{
    private readonly SocialDbContext _dbContext;
    
    public CreateMovieCommandHandler(SocialDbContext dbContext)
    {
        _dbContext = dbContext;   
    }
    
    public async Task<ErrorOr<MovieDto>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var (title, genre, releaseYear) = request.CreateMovieDto;
        
        var movie = new Movie
        {
            Title = title,
            Genre = genre,
            ReleaseYear = releaseYear
        };
        
        var result = await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return MovieMapper.MovieToMovieDto(result.Entity);
    }
}