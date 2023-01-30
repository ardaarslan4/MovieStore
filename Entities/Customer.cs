using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        public string? CustomerAdi{get;set;}
        public string? CustomerSoyadi{get;set;}
        public List<Genre>? FavoriFilmTurleri{get;set;}
        public List<Film>? SatinAlinanFilmler{get;set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        
    }
}