using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model {get;set;}
        private readonly IMovieStoreDbContext _context;

        public CreateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.FilmTurleri.SingleOrDefault(x => x.TurIsmi == Model.TurIsmi);
            if (genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut.");
            
            genre = new Genre();
            genre.TurIsmi = Model.TurIsmi;
            _context.FilmTurleri.Add(genre);
            _context.SaveChanges(); 
        }
    }

    public class CreateGenreModel
    {
        public string? TurIsmi {get;set;}
    }
}