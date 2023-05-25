using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoMarka
    {
        public DtoMarka()
        {
            IsDeleted=false;
            DtoModels = new List<DtoModel>();
        }
        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public bool IsDeleted { get; set; }
        public string MarkaGorselUrl { get; set; }
        public IFormFile MarkaGorselFile { get; set; }
        public virtual List<DtoModel> DtoModels { get; set; }
    }
}
