using FluentValidation;
using WebApi.Application.YonetmenOperations.Commands.DeleteYonetmen;

namespace WebApi.Application.YonetmenOperations.Commands.DeleteYonetmen
{
    public class DeleteYonetmenCommandValidator : AbstractValidator<DeleteYonetmenCommand>
    {
        public DeleteYonetmenCommandValidator()
        {
            RuleFor(command=> command.YonetmenId).GreaterThan(0).NotEmpty();
        }
    }
}