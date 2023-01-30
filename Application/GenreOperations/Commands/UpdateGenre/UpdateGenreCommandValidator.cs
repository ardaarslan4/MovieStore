using FluentValidation;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command=>command.Model.TurIsmi).MinimumLength(4).When(x=>x.Model.TurIsmi != string.Empty);

        }
    }
}