using Application.Features.CinemaFeat.CQRS.Commands;
using Application.Features.CinemaFeat.DTOs;
using MediatR;
using Riok.Mapperly.Abstractions;

namespace WebApi.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class CinemaMapper
{
    public static partial CreateCinemaCommand CreateCinemaDtoToCreateCinemaCommand(CreateCinemaDto createCinemaDto);
    public static partial UpdateCinemaCommand UpdateCinemaDtoToUpdateCinemaCommand(UpdateCinemaDto updateCinemaDto);

}