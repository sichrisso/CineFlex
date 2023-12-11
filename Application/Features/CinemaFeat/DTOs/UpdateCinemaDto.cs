namespace Application.Features.CinemaFeat.DTOs;

public record UpdateCinemaDto(
    int Id,
    string Name,
    string Location,
    string PhoneNo
);
