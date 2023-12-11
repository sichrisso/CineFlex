// using MediatR;

// namespace Application.Features.Movie.CQRS.Commands
// {
//     public class DeleteMovieCommand : IRequest
//     {
//         public int MovieId { get; set; }
//     }
// }

// using Application.Dtos;
// using MediatR;
// using ErrorOr;

// namespace Application.Features.Command;

// public record DeleteMovieCommand(DeleteMovieDto UpdateMovieDto) : IRequest<ErrorOr<MovieDto>>;