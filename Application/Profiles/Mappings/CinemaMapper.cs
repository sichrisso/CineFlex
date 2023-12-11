using Application.Features.CinemaFeat.DTOs;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Profiles.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class CinemaMapper
{
    public static partial CinemaDto CinemaToCinemaDto(Cinema cinema);
}



