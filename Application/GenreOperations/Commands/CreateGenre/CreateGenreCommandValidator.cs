using FluentValidation;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command=>command.Model.TurIsmi).NotEmpty().MinimumLength(4);
        }
    }
}