namespace Application.Dtos;

public record CreateMovieDto(
    string Title,
    string Genre,
    int ReleaseYear
);