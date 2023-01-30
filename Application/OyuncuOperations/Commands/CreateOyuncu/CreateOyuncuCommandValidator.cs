using System;
using FluentValidation;
using WebApi.Application.OyuncuOperations.Commands.CreateOyuncu;

namespace WebApi.Application.OyuncuOperations.Commands.CreateOyuncu
{
    public class CreateOyuncuCommandValidator : AbstractValidator<CreateOyuncuCommand>
    {
        public CreateOyuncuCommandValidator()
        {
            RuleFor(command=> command.Model.OyuncuAdi).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.OyuncuSoyadi).NotEmpty().MinimumLength(3);
      
        }
    }
}