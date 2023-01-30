using FluentValidation;
using WebApi.Application.OyuncuOperations.Commands.DeleteOyuncu;

namespace WebApi.Application.FilmOperations.Commands.DeleteFilm
{
    public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
    {
        public DeleteFilmCommandValidator()
        {
            RuleFor(command=> command.filmId).NotEmpty().GreaterThan(0);
        }
    }
}