using FluentValidation;

namespace Application.Features.Command;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(m => m.CreateMovieDto.Title).NotEmpty().WithMessage("Title is required!");
        RuleFor(m => m.CreateMovieDto.ReleaseYear).ExclusiveBetween(1000, 3000).WithMessage("Release year must be between 1000 and 3000!");
    }
}