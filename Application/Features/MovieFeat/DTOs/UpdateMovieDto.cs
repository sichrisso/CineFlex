namespace Application.Features.MovieFeat.DTOs;

public record UpdateMovieDto(
    int Id,
    string Title,
    string Genre,
    int ReleaseYear
);