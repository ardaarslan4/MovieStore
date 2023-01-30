using WebApi.DBOperations;
using AutoMapper;
using System.Collections;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.FilmTurleri.Where(x=>x.IsActive).OrderBy(x=>x.Id); //Genrelerimi DB'den çekicem.
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }

    public class GenresViewModel
    {
        public int Id {get;set;}
        public string? TurIsmi {get;set;}
    }
}