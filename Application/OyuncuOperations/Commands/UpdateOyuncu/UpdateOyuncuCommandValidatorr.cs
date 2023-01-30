using FluentValidation;


namespace WebApi.Application.OyuncuOperations.Commands.UpdateOyuncu
{
    public class UpdateOyuncuCommandValidator : AbstractValidator<UpdateOyuncuCommand>
    {
        public UpdateOyuncuCommandValidator()
        {
            RuleFor(command=> command.Model.OyuncuAdi).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.Model.OyuncuSoyadi).NotEmpty().MinimumLength(4);
  
        }
    }
}