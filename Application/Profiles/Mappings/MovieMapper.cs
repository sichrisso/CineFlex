using Application.Features.MovieFeat.DTOs;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Profiles.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class MovieMapper
{
    public static partial MovieDto MovieToMovieDto(Movie movie);
}