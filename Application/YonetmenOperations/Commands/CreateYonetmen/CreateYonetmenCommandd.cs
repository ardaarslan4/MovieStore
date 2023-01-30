using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.YonetmenOperations.Commands.CreateYonetmen
{
    public class CreateYonetmenCommand
    {
        public CreateYonetmenModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateYonetmenCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var yonetmen =_dbContext.Yonetmenler.SingleOrDefault(x=>x.YonetmenAdi== Model.YonetmenAdi && x.YonetmenSoyadi==Model.YonetmenSoyadi);
            
            if(yonetmen is not null)
                throw new InvalidOperationException("Yonetmen Zaten Mevcut.");

            yonetmen=_mapper.Map<Yonetmen>(Model);
            _dbContext.Yonetmenler.Add(yonetmen);
            _dbContext.SaveChanges();
        }
    }

    public class CreateYonetmenModel
    {
        public string? YonetmenAdi {get; set;}
        public string? YonetmenSoyadi {get; set;}
        
    }
}