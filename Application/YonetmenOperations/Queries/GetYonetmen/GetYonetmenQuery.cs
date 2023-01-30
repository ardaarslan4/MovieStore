using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.YonetmenOperations.Queries.GetYonetmen
{
    public class GetYonetmenQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetYonetmenQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<YonetmenViewModel> Handle()
        {
            var yonetmenler=_dbContext.Yonetmenler.OrderBy(x=>x.Id);
            List<YonetmenViewModel> returnObj =_mapper.Map<List<YonetmenViewModel>>(yonetmenler);
            return returnObj;
        }
    }

    public class YonetmenViewModel
    {
        public int Id { get; set; }
        public string YonetmenAdi { get; set; }
        public string YonetmenSoyadi { get; set; }
        
        
    }
}