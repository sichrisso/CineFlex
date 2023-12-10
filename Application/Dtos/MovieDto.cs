namespace Application.Dtos;

public record MovieDto(
    int Id,
    string Title,
    string Genre,
    int ReleaseYear
);