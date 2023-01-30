using System;
using FluentValidation;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.YonetmenOperations.Commands.DeleteYonetmen
{
    public class DeleteYonetmenCommand
    {
        public int YonetmenId {get; set;}
        private readonly IMovieStoreDbContext _context;
        public DeleteYonetmenCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var Yonetmen = _context.Yonetmenler.SingleOrDefault(x=>x.Id == YonetmenId);
            if(Yonetmen is null)
               throw new InvalidOperationException("Silinecek Yonetmen bulunamadı.");
            
            _context.Yonetmenler.Remove(Yonetmen);
            _context.SaveChanges();
        }
    }
}