using System;
using FluentValidation;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.OyuncuOperations.Commands.DeleteOyuncu
{
    public class DeleteOyuncuCommand
    {
        public int oyuncuId {get; set;}
        private readonly IMovieStoreDbContext _context;
        public DeleteOyuncuCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var oyuncu = _context.Oyuncular.SingleOrDefault(x=>x.Id == oyuncuId);
            if(oyuncu is null)
               throw new InvalidOperationException("Silinecek oyuncu bulunamadı.");
            
            _context.Oyuncular.Remove(oyuncu);
            _context.SaveChanges();
        }
    }
}