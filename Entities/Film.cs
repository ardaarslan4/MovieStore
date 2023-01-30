using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set;}
        public string? FilmAdi {get; set;}
        public DateTime FilmYili{get; set;}
        public Genre? FilmTuru{get;set;}
        public int FilmTuruId{get;set;}
        public Yonetmen? Yonetmen{get;set;}
        public int YonetmenId{get;set;}
        public double Fiyat{get;set;}
        public List <Oyuncu>? Oyuncular{get;set;}
        public Oyuncu? Oyuncu{get;set;}



    }
}