using FluentValidation;


namespace WebApi.Application.YonetmenOperations.Commands.UpdateYonetmen
{
    public class UpdateYonetmenCommandValidator : AbstractValidator<UpdateYonetmenCommand>
    {
        public UpdateYonetmenCommandValidator()
        {
            RuleFor(command=> command.Model.YonetmenAdi).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.Model.YonetmenSoyadi).NotEmpty().MinimumLength(4);
            
        }
    }
}