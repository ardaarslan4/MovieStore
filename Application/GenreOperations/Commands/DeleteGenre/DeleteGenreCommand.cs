using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId {get;set;}
        private readonly IMovieStoreDbContext _context;
        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.FilmTurleri.SingleOrDefault(x=>x.Id ==GenreId);
            if(genre is null)
                throw new InvalidOperationException("Film türü bulunamadi");

            _context.FilmTurleri.Remove(genre);
            _context.SaveChanges();
        }

    }
}