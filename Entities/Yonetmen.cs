using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Yonetmen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        public string? YonetmenAdi {get; set;}
        public string? YonetmenSoyadi {get; set;}
        


    }
}