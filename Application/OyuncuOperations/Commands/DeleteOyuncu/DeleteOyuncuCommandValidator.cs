using FluentValidation;
using WebApi.Application.OyuncuOperations.Commands.DeleteOyuncu;

namespace WebApi.Application.OyuncuOperations.Commands.DeleteOyuncu
{
    public class DeleteOyuncuCommandValidator : AbstractValidator<DeleteOyuncuCommand>
    {
        public DeleteOyuncuCommandValidator()
        {
            RuleFor(command=> command.oyuncuId).GreaterThan(0).NotEmpty();
        }
    }
}