using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoModel
    {
        public DtoModel()
        {
            IsDeleted=false;
            DtoMarka = new DtoMarka();
            Uruns = new List<DtoUrun>();
        }
        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int ModelId { get; set; }
        public string ModelAdi { get; set; }
        
        public int MarkaId { get; set; }
        public virtual DtoMarka DtoMarka { get; set; }

        public bool IsDeleted { get; set; }
        public string ModelGorselUrl { get; set; }
        public IFormFile ModelGorselFile { get; set; }


        public virtual List<DtoUrun> Uruns { get; set; }

    }
}
