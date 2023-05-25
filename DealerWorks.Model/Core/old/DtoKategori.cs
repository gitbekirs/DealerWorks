using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoKategori
    {
        public DtoKategori()
        {
            IsDeleted=false;
            EklenmeZamani=DateTime.Now;
            //DtoMarkas = new List<DtoMarka>();
        }

        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public bool IsDeleted { get; set; }
        public string KategoriGorselUrl { get; set; }
        public DateTime EklenmeZamani { get; set; }
        public IFormFile KategoriGorselFile { get; set; }

        //public virtual List<DtoMarka> DtoMarkas { get; set; }

    }
}
