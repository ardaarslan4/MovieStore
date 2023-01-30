using FluentValidation;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail;

namespace WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail
{
    public class GetOyuncuDetailQueryValidator : AbstractValidator<GetOyuncuDetailQuery>
    {
        public GetOyuncuDetailQueryValidator()
        {
            RuleFor(query => query.OyuncuId).GreaterThan(0);
            
        }
    }
}