namespace Application.Features.MovieFeat.DTOs;

public record MovieDto(
    int Id,
    string Title,
    string Genre,
    int ReleaseYear
);