using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Queries.GetFilmDetail
{
    public class GetFilmDetailQuery
    {
        public int FilmId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetFilmDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FilmDetailViewModel Handle()
        {
            var film = _context.Oyuncular.SingleOrDefault(x=>x.Id == FilmId);
            if(film is null)
                throw new InvalidOperationException("Film Bulunamadi.");
            return _mapper.Map<FilmDetailViewModel>(film);
        }
    }

    public class FilmDetailViewModel
    {
        public string? FilmAdi{get;set;}
        public DateTime? FilmYili{get;set;}
        public Genre? FilmTuru{get;set;}
        public string? Yonetmen{get;set;}
        public List<Oyuncu>? Oyuncular{get;set;}
        public double Fiyat{get;set;}
        
    }
}