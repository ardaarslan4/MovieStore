using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.OyuncuOperations.Commands.UpdateOyuncu
{
    public class UpdateOyuncuCommand
    {
        public int OyuncuId {get;set;}
        public UpdateOyuncuModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateOyuncuCommand(IMovieStoreDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var oyuncu = _dbContext.Oyuncular.SingleOrDefault(x=>x.Id== OyuncuId);
             if(oyuncu is null)
                throw new InvalidOperationException("Oyuncu Bulunamadı.");
            
            oyuncu.OyuncuAdi = Model.OyuncuAdi == default ? oyuncu.OyuncuAdi : Model.OyuncuAdi;
            oyuncu.OyuncuSoyadi = Model.OyuncuSoyadi == default ? oyuncu.OyuncuSoyadi : Model.OyuncuSoyadi;
            
            
            
            _dbContext.Oyuncular.Update(oyuncu);
            _dbContext.SaveChanges();

        }
    }

    public class UpdateOyuncuModel
    {
        public string? OyuncuAdi {get; set;}
        public string? OyuncuSoyadi {get; set;}
       
    }
}