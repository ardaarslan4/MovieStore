using System;
using FluentValidation;


namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command=> command.Model.CustomerAdi).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.CustomerSoyadi).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.Model.FavoriFilmTurleri).NotEmpty();
            RuleFor(command=>command.Model.SatinAlinanFilmler).NotEmpty();
            RuleFor(command=>command.Model.Email).NotEmpty().MinimumLength(10);
            RuleFor(command=>command.Model.Password).NotEmpty().MinimumLength(8);
           

        }
    }
}