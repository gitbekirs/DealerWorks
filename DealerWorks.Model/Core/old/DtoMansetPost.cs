using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoMansetPost
    {

        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int MansetPostId { get; set; }

        public string MansetPostGorselUrl { get; set; }
        public string MansetPostBaslik { get; set; }
        public string MansetPostSpot { get; set; }
        public DateTime MansetPostGecerliTarih { get; set; }
        public IFormFile MansetPostGorselFile { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
