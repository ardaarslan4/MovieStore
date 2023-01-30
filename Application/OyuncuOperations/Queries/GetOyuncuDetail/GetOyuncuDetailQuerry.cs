using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail
{
    public class GetOyuncuDetailQuery
    {
        public int OyuncuId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetOyuncuDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OyuncuDetailViewModel Handle()
        {
            var oyuncu = _context.Oyuncular.SingleOrDefault(x=>x.Id == OyuncuId);
            if(oyuncu is null)
                throw new InvalidOperationException("Oyuncu Bulunamadi.");
            return _mapper.Map<OyuncuDetailViewModel>(oyuncu);
        }
    }

    public class OyuncuDetailViewModel
    {
        public int Id { get; set; }
        public string OyuncuAdi { get; set; }
        public string OyuncuSoyadi { get; set; }
        public List<Film> OynadigiFilmler { get; set; }
        
    }
}