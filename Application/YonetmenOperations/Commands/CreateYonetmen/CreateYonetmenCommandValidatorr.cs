
using FluentValidation;
using WebApi.Application.YonetmenOperations.Commands.CreateYonetmen;

namespace WebApi.Application.YonetmenOperations.Commands.CreateYonetmen
{
    public class CreateYonetmenCommandValidator : AbstractValidator<CreateYonetmenCommand>
    {
        public CreateYonetmenCommandValidator()
        {
            RuleFor(command=> command.Model.YonetmenAdi).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.YonetmenSoyadi).NotEmpty().MinimumLength(3);
            
        }
    }
}