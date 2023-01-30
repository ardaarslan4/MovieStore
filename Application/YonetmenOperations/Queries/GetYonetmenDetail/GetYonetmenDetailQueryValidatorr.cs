using FluentValidation;


namespace WebApi.Application.YonetmenOperations.Queries.GetYonetmenDetail
{
    public class GetYonetmenDetailQueryValidator : AbstractValidator<GetYonetmenDetailQuery>
    {
        public GetYonetmenDetailQueryValidator()
        {
            RuleFor(query => query.YonetmenId).GreaterThan(0);
            
        }
    }
}