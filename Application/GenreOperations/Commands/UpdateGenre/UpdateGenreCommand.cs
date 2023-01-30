using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId {get;set;}
        public UpdateGenreModel Model {get;set;}
        private readonly IMovieStoreDbContext _context;
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.FilmTurleri.SingleOrDefault(x=>x.Id ==GenreId);
            if(genre is null)
                throw new InvalidOperationException("Film türü bulunamadi");
            
            if(_context.FilmTurleri.Any(x=>x.TurIsmi.ToLower() ==Model.TurIsmi.ToLower()&& x.Id != GenreId))
                throw new InvalidOperationException("Ayni isimli bir film türü zaten mevcut");

            genre.TurIsmi = string.IsNullOrEmpty (Model.TurIsmi.Trim()) ? genre.TurIsmi:Model.TurIsmi; //Sonda boşluk varsa sil oluyor Trim
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string? TurIsmi {get;set;}
        public bool IsActive {get;set;} =true;

    }
}