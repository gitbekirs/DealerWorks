using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoSiteProfil
    {

        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int ProfilBilgiId { get; set; }
        public string ProfilBilgiAdi { get; set; }
        public string ProfilBilgiDeger { get; set; }
    }
}
