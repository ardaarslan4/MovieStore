using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Queries.GetFilm
{
    public class GetFilmQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<FilmViewModel> Handle()
        {
            var filmler=_dbContext.Filmler.OrderBy(x=>x.Id);
            List<FilmViewModel> returnObj =_mapper.Map<List<FilmViewModel>>(filmler);
            return returnObj;
        }
    }

    public class FilmViewModel
    {
        public string? FilmAdi{get;set;}
        public int FilmYili{get;set;}
        public Genre? FilmTuru{get;set;}
        public string? Yonetmen{get;set;}
        public List<Oyuncu>? Oyuncular{get;set;}
        public double Fiyat{get;set;}
        
    }
}