using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Application.SiparisOperations.Queries.GetSiparis
{
    public class GetSiparisQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSiparisQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<SiparisViewModel> Handle()
        {
            var siparisler=_dbContext.Siparisler.OrderBy(x=>x.CustomerId);
            List<SiparisViewModel> returnObj =_mapper.Map<List<SiparisViewModel>>(siparisler);
            return returnObj;
        }
    }

    public class SiparisViewModel
    {
        public int FilmAdi { get; set; }
        public int CustomerAdi { get; set; }
        public DateTime SatinAlinmaTarihi { get; set; } = DateTime.Now.Date;
        public int Fiyat{get;set;}
        
        
    }
}