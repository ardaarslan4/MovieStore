using FluentValidation;

namespace WebApi.Application.SiparisOperations.Commands.CreateSiparis
{
    public class CreateSiparisCommandValidator : AbstractValidator<CreateSiparisCommand>
    {    
        public CreateSiparisCommandValidator()
        {
            RuleFor(command=> command.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.FilmId).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.Fiyat).NotEmpty().GreaterThan(1);
            RuleFor(command=> command.Model.SatinAlinmaTarihi.Date).NotEmpty();        
        }
    }
}