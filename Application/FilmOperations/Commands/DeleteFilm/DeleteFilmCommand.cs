using System;
using FluentValidation;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.FilmOperations.Commands.DeleteFilm
{
    public class DeleteFilmCommand
    {
        public int filmId {get; set;}
        private readonly IMovieStoreDbContext _context;
        public DeleteFilmCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var film = _context.Filmler.SingleOrDefault(x=>x.Id == filmId);
            if(film is null)
               throw new InvalidOperationException("Silinecek film bulunamadi.");
            
            _context.Filmler.Remove(film);
            _context.SaveChanges();
        }
    }
}