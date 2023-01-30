using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;


namespace WebApi.DBOperations
{
    public class FilmTurleriGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MovieStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDBContext>>()))
            {
                if(context.Filmler.Any()) //Eğer burada hiç veri varsa
                {
                    return;
                }
                context.FilmTurleri.AddRange
                (
                    new Genre
                    {
                        TurIsmi = "Comedy"
                    },
                    new Genre
                    {
                        TurIsmi = "ScienceFiction"
                    },
                    new Genre
                    {
                        TurIsmi = "Romance"
                    },
                    new Genre
                    {
                        TurIsmi = "Action"
                    }
                );

                context.Yonetmenler.AddRange(
                    new Yonetmen{YonetmenAdi = "Alfred", YonetmenSoyadi = "Hitchcock"},
                    new Yonetmen{YonetmenAdi = "Orson", YonetmenSoyadi = "Welles"},
                    new Yonetmen{YonetmenAdi = "John", YonetmenSoyadi = "Ford"},
                    new Yonetmen{YonetmenAdi = "Howard", YonetmenSoyadi = "Hawks"},
                    new Yonetmen{YonetmenAdi = "Martin", YonetmenSoyadi = "Scorsese"},
                    new Yonetmen{ YonetmenAdi = "Akira", YonetmenSoyadi = "Kurosawa"});

                context.Oyuncular.AddRange(
                    new Oyuncu{OyuncuAdi = "Robert", OyuncuSoyadi = "DeNiro"},
                    new Oyuncu{OyuncuAdi = "Jack", OyuncuSoyadi = "Nicholson"},
                    new Oyuncu{OyuncuAdi = "Marlon", OyuncuSoyadi = "Brando"},
                    new Oyuncu{OyuncuAdi = "Denzel", OyuncuSoyadi = "Washington"},
                    new Oyuncu{OyuncuAdi = "Katharine", OyuncuSoyadi = "Hepburn"},
                    new Oyuncu{OyuncuAdi = "Humphrey", OyuncuSoyadi = "Bogart"},
                    new Oyuncu{OyuncuAdi = "Meryl", OyuncuSoyadi = "Streep"},
                    new Oyuncu{OyuncuAdi = "Daniel", OyuncuSoyadi = "DayLewis"},
                    new Oyuncu{OyuncuAdi = "Sidney", OyuncuSoyadi = "Poitier"},
                    new Oyuncu{OyuncuAdi = "Clark", OyuncuSoyadi = "Geble"},
                    new Oyuncu{OyuncuAdi = "Ingrid", OyuncuSoyadi = "Bergman"},
                    new Oyuncu{OyuncuAdi = "Tom", OyuncuSoyadi = "Hanks"},
                    new Oyuncu{OyuncuAdi = "Elizabeth", OyuncuSoyadi = "Taylor"},
                    new Oyuncu{ OyuncuAdi = "Bette", OyuncuSoyadi = "Davis"});

                context.Filmler.AddRange(
                    new Film{
                        FilmAdi = "The Godfater", 
                        FilmTuruId = 6, YonetmenId = 1, Fiyat = 30,
                        FilmYili = new DateTime(1972), 
                        Oyuncular = new List<Oyuncu>()},
                    new Film{
                        FilmAdi = "Citizen Kane", 
                        FilmTuruId = 3, YonetmenId = 2, Fiyat = 20,
                        FilmYili = new DateTime(1941), 
                        Oyuncular = new List<Oyuncu>()},
                    new Film{
                        FilmAdi = "La Dolce Vita", 
                        FilmTuruId = 7, YonetmenId = 3, Fiyat = 10,
                        FilmYili = new DateTime(1960), 
                        Oyuncular = new List<Oyuncu>()},
                    new Film{
                        FilmAdi = "Seven Samurai", 
                        FilmTuruId = 1, YonetmenId = 4, Fiyat = 40,
                        FilmYili = new DateTime(1954), 
                        Oyuncular = new List<Oyuncu>()},
                    new Film{
                        FilmAdi = "There Will Be Blood", 
                        FilmTuruId = 3, YonetmenId = 5, Fiyat = 25,
                        FilmYili = new DateTime(2007), 
                        Oyuncular = new List<Oyuncu>()},
                    new Film{
                        FilmAdi = "Singing in the Rain", 
                        FilmTuruId = 5, YonetmenId = 6, Fiyat = 15,
                        FilmYili = new DateTime(1952), 
                        Oyuncular = new List<Oyuncu>()});

                context.Customers.AddRange(
                    new Customer{
                        CustomerAdi = "Aslı",
                        CustomerSoyadi = "Yılmaz",
                        SatinAlinanFilmler = new List<Film>(),
                        FavoriFilmTurleri = new List<Genre>(),
                        Email = "aslı@hotmail.com",
                        Password = "123456"},
                    new Customer{
                        CustomerAdi = "Enver",
                        CustomerSoyadi = "Canlı",
                        SatinAlinanFilmler = new List<Film>(),
                        FavoriFilmTurleri = new List<Genre>(),
                        Email = "enver@hotmail.com",
                        Password = "123321",},
                    new Customer{
                        CustomerAdi = "Kamil",
                        CustomerSoyadi = "Kosucu",
                        SatinAlinanFilmler = new List<Film>(),
                        FavoriFilmTurleri = new List<Genre>(),
                        Email = "enver@hotmail.com",
                        Password = "123321",});     

                                
            }
        }
    }
}