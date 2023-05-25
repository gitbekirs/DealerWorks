using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoUrunFiyat
    {
        public DtoUrunFiyat()
        {
            DtoUrun = new DtoUrun();
            GecerlilikTarihi = DateTime.Now.AddYears(1);
            EklenmeTarihi=DateTime.Now;
        }
        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int UrunFiyatId { get; set; }
        public int UrunId { get; set; }
        public virtual DtoUrun DtoUrun { get; set; }

        public decimal Fiyat { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
        public DateTime EklenmeTarihi { get; set; }


        //public virtual T10Urun Urun { get; set; }
    }
}
