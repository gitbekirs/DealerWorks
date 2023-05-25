using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoKullanici
    {
        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciEposta { get; set; }
        public string KullaniciTelefon { get; set; }
        public string KullaniciGorselUrl { get; set; }
        public IFormFile KullaniciGorselFile { get; set; }

        //public bool IsDeleted { get; set; }
        //public string EpostaDogrulamaKod { get; set; }
        //public DateTime? EpostaDogrulamaKodGecerTarih { get; set; }
        //public bool? EpostaDogrulandi { get; set; }
    }
}
