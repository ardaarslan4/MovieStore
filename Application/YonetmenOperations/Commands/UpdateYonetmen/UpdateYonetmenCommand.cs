using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.YonetmenOperations.Commands.UpdateYonetmen
{
    public class UpdateYonetmenCommand
    {
        public int YonetmenId {get;set;}
        public UpdateYonetmenModel Model {get;set;}
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateYonetmenCommand(IMovieStoreDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var Yonetmen = _dbContext.Yonetmenler.SingleOrDefault(x=>x.Id== YonetmenId);
             if(Yonetmen is null)
                throw new InvalidOperationException("Yonetmen Bulunamadı.");
            
            Yonetmen.YonetmenAdi = Model.YonetmenAdi == default ? Yonetmen.YonetmenAdi : Model.YonetmenAdi;
            Yonetmen.YonetmenSoyadi = Model.YonetmenSoyadi == default ? Yonetmen.YonetmenSoyadi : Model.YonetmenSoyadi;
            
            
            
            _dbContext.Yonetmenler.Update(Yonetmen);
            _dbContext.SaveChanges();

        }
    }

    public class UpdateYonetmenModel
    {
        public string? YonetmenAdi {get; set;}
        public string? YonetmenSoyadi {get; set;}
        
    }
}