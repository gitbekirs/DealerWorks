using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.ComponentModel.DataAnnotations;


namespace DealerApp.DTOs
{
    public class DtoUrunGorsel
    {
       
        public DtoUrunGorsel()
        {
            DtoUrun = new DtoUrun();
            Isdeleted=false;
            UrunGorselFile =  new FormFile(Stream.Null, 0, 0, "", "");//test edilecek!....
        }
        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int UrunGorselId { get; set; }
        public string UrunGorselUrl { get; set; }
        public int UrunId { get; set; }
        public virtual DtoUrun DtoUrun { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
        public bool Isdeleted { get; set; }
        public IFormFile UrunGorselFile { get; set; }
    }
}
