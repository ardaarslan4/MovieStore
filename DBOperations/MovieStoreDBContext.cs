using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class MovieStoreDBContext: DbContext, IMovieStoreDbContext
    {
        public MovieStoreDBContext(DbContextOptions<MovieStoreDBContext> options):base(options)
        {
            
        }
        public DbSet<Film> Filmler {get;set;}
        public DbSet<Genre> FilmTurleri {get;set;}
        public DbSet<Yonetmen> Yonetmenler {get;set;}
        public DbSet<Oyuncu> Oyuncular {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Siparis> Siparisler {get;set;}


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}