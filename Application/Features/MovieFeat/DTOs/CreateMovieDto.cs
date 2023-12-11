namespace Application.Features.MovieFeat.DTOs;

public record CreateMovieDto(
    string Title,
    string Genre,
    int ReleaseYear
);