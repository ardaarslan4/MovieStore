using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Commands.CreateFilm
{
    public class CreateFilmCommand
    {
        public CreateFilmModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateFilmCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var film =_dbContext.Filmler.SingleOrDefault(x=>x.FilmAdi== Model.FilmAdi);
            
            if(film is not null)
                throw new InvalidOperationException("Film Zaten Mevcut.");

            film=_mapper.Map<Film>(Model);
            _dbContext.Filmler.Add(film);
            _dbContext.SaveChanges();
        }
    }

    public class CreateFilmModel
    {
        public string? FilmAdi{get;set;}
        public DateTime FilmYili{get;set;}
        public int FilmTuruId{get;set;}
        public int YonetmenId{get;set;}
        public List<Oyuncu>?Oyuncular{get;set;}
        public double Fiyat{get;set;}
    }
}