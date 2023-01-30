using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Film> Filmler {get;set;}
        DbSet<Genre> FilmTurleri {get;set;}
        DbSet<Yonetmen> Yonetmenler {get;set;}
        DbSet<Oyuncu> Oyuncular {get;set;}
        DbSet<Customer> Customers {get;set;}
        public DbSet<Siparis> Siparisler {get;set;}
        

        int SaveChanges();
    }
}