namespace Application.Dtos;

public record UpdateMovieDto(
    int Id,
    string Title,
    string Genre,
    int ReleaseYear
);