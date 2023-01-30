using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OyuncuOperations.Queries.GetOyuncu
{
    public class GetOyuncuQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOyuncuQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<OyuncuViewModel> Handle()
        {
            var oyuncular=_dbContext.Oyuncular.OrderBy(x=>x.Id);
            List<OyuncuViewModel> returnObj =_mapper.Map<List<OyuncuViewModel>>(oyuncular);
            return returnObj;
        }
    }

    public class OyuncuViewModel
    {
        public int Id { get; set; }
        public string OyuncuAdi { get; set; }
        public string OyuncuSoyadi { get; set; }
        public List<Film> OynadigiFilmler { get; set; }
        
    }
}