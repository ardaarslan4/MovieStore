using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OyuncuOperations.Commands.CreateOyuncu
{
    public class CreateOyuncuCommand
    {
        public CreateOyuncuModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOyuncuCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var oyuncu =_dbContext.Oyuncular.SingleOrDefault(x=>x.OyuncuAdi== Model.OyuncuAdi && x.OyuncuSoyadi==Model.OyuncuSoyadi);
            
            if(oyuncu is not null)
                throw new InvalidOperationException("Oyuncu Zaten Mevcut.");

            oyuncu=_mapper.Map<Oyuncu>(Model);
            _dbContext.Oyuncular.Add(oyuncu);
            _dbContext.SaveChanges();
        }
    }

    public class CreateOyuncuModel
    {
        public string? OyuncuAdi {get; set;}
        public string? OyuncuSoyadi {get; set;}
        
    }
}