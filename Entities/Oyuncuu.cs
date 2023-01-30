using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Oyuncu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? OyuncuAdi {get; set;}
        public string? OyuncuSoyadi {get; set;}
        
    }
}