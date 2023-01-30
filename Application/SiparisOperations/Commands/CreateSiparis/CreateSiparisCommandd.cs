using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.SiparisOperations.Commands.CreateSiparis
{
    public class CreateSiparisCommand
    {
        public CreateSiparisModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateSiparisCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var siparis =_dbContext.Siparisler.SingleOrDefault(x=>x.CustomerId== Model.CustomerId && x.FilmId==Model.FilmId);
            
            if(siparis is not null)
                throw new InvalidOperationException("Siparis Zaten Mevcut.");

            siparis=_mapper.Map<Siparis>(Model);
            _dbContext.Siparisler.Add(siparis);
            _dbContext.SaveChanges();
        }
    }

    public class CreateSiparisModel
    {
        public int FilmId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SatinAlinmaTarihi { get; set; } = DateTime.Now.Date;
        public int Fiyat{get;set;}
        
    }
}