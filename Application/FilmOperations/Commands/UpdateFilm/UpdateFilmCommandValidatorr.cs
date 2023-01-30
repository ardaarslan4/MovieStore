using FluentValidation;


namespace WebApi.Application.FilmOperations.Commands.UpdateFilm
{
    public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmCommandValidator()
        {
            RuleFor(command=> command.FilmId).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.FilmAdi).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.FilmTuruId).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.Model.FilmYili.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.Model.Fiyat).NotEmpty().GreaterThan(1);
            RuleFor(command=>command.Model.Oyuncular).NotEmpty();
            RuleFor(command=>command.Model.YonetmenId).NotEmpty().GreaterThan(0);


        }
    }
}