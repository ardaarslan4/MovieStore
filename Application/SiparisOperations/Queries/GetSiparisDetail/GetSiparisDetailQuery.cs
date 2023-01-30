using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.SiparisOperations.Queries.GetSiparisDetail
{
    public class GetSiparisDetailQuery
    {
        public int SiparisId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetSiparisDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SiparisDetailViewModel Handle()
        {
            var siparis = _context.Siparisler.SingleOrDefault(x=>x.Id == SiparisId);
            if(siparis is null)
                throw new InvalidOperationException("Yonetmen Bulunamadi.");
            return _mapper.Map<SiparisDetailViewModel>(siparis);
        }
    }

    public class SiparisDetailViewModel
    {
        public int FilmAdi { get; set; }
        public int CustomerAdi { get; set; }
        public DateTime SatinAlinmaTarihi { get; set; } = DateTime.Now.Date;
        public int Fiyat{get;set;}
        
        
    }
}