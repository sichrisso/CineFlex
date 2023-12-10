using Application.Dtos;
using Domain.Entites;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class MovieMapper
{
    public static partial MovieDto MovieToMovieDto(Movie movie);
}