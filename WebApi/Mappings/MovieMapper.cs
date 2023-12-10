using Application.Dtos;
using Application.Features.Command;
using Riok.Mapperly.Abstractions;

namespace WebApi.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class MovieMapper
{
    public static partial CreateMovieCommand CreateMovieDtoToCreateMovieCommand(CreateMovieDto createMovieDto);
    public static partial UpdateMovieCommand UpdateMovieDtoToUpdateMovieCommand(UpdateMovieDto updateMovieDto);
}