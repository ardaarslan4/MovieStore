using FluentValidation;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail;

namespace WebApi.Application.FilmOperations.Queries.GetFilmDetail
{
    public class GetFilmDetailQueryValidator : AbstractValidator<GetFilmDetailQuery>
    {
        public GetFilmDetailQueryValidator()
        {
            RuleFor(query => query.FilmId).GreaterThan(0);
            
        }
    }
}