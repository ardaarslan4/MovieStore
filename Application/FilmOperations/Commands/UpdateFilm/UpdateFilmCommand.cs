using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Commands.UpdateFilm
{
    public class UpdateFilmCommand
    {
        public int FilmId {get;set;}
        public UpdateFilmModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateFilmCommand(IMovieStoreDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var film = _dbContext.Filmler.SingleOrDefault(x=>x.Id== FilmId);
             if(film is null)
                throw new InvalidOperationException("Film Bulunamadi.");
            
            film.FilmAdi = Model.FilmAdi == default ? film.FilmAdi : Model.FilmAdi;
            film.FilmYili = Model.FilmYili == default ? film.FilmYili : Model.FilmYili;
            film.FilmTuruId = Model.FilmTuruId ==default ? film.FilmTuruId:Model.FilmTuruId;
            film.Oyuncular = Model.Oyuncular == default ? film.Oyuncular:Model.Oyuncular;
            film.YonetmenId= Model.YonetmenId == default ? film.YonetmenId:Model.YonetmenId;
            film.Fiyat= Model.Fiyat == default ? film.Fiyat:Model.Fiyat;
            
            _dbContext.Filmler.Update(film);
            _dbContext.SaveChanges();

        }
    }

    public class UpdateFilmModel
    {
        public string? FilmAdi{get;set;}
        public DateTime FilmYili{get;set;}
        public int FilmTuruId{get;set;}
        public int YonetmenId{get;set;}
        public List<Oyuncu>?Oyuncular{get;set;}
        public double Fiyat{get;set;}
    }
}