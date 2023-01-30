using FluentValidation;


namespace WebApi.Application.SiparisOperations.Queries.GetSiparisDetail
{
    public class GetSiparisDetailQueryValidator : AbstractValidator<GetSiparisDetailQuery>
    {
        public GetSiparisDetailQueryValidator()
        {
            RuleFor(query => query.SiparisId).GreaterThan(0);
            
        }
    }
}