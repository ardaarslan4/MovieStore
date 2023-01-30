using System;

namespace WebApi.Entities
{
    public class Siparis
    {
        public int Id{get;set;}
        public int CustomerId{get;set;}
        public Customer? Customer{get;set;}
        public int FilmId{get;set;}
        public Film? Film{get;set;}
        public string? FilmAdi{get;set;}
        public DateTime SatinAlinmaTarihi{get;set;}
        public int FilmBedeli{get;set;}
        public Genre? FilmTuru{get;set;}
        public int FilmTuruId{get;set;}
    }
}