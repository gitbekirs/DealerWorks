using System.ComponentModel.DataAnnotations;

namespace DealerApp.DTOs
{
    public class DtoUrun
    {
        public DtoUrun()
        {
            IsDeleted=false;
            DtoUrunFiyats = new List<DtoUrunFiyat>();
            DtoUrunGorsels = new List<DtoUrunGorsel>();
        }

        [Key]//id kolonu sadece Id adında değil de UrunId gibi bir ifadeyse primary key tanıması için bu attribute'i kullanmalıyız.
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        
        public int KategoriId { get; set; }
        public virtual DtoKategori DtoKategori { get; set; }

        public int MarkaId { get; set; }
        public virtual DtoMarka DtoMarka { get; set; }

        public int ModelId { get; set; }
        public virtual DtoModel DtoModel { get; set; }
        
        public bool IsDeleted { get; set; }

        public virtual List<DtoUrunFiyat> DtoUrunFiyats { get; set; }
        public virtual List<DtoUrunGorsel> DtoUrunGorsels { get; set; }
        
        //public virtual T10Kategori Kategori { get; set; }
        //public virtual T10Marka Marka { get; set; }
        //public virtual T10Model Model { get; set; }
        //public virtual ICollection<T10UrunFiyat> T10UrunFiyat { get; set; }

    }
}
