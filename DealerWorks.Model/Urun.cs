using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class Urun : ModelBase
    {
        public Urun()
        {
            IsDeleted=false;
            EklenmeZamani=DateTime.Now;
            Kategori= new Kategori();
            Marka=new Marka();
            Model = new Model();
            UrunFiyats= new List<UrunFiyat>();
            UrunGorsels= new List<UrunGorsel>();
        }

        public string UrunAdi { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }


        public DateTime EklenmeZamani { get; set; }
        public DateTime? GuncellenmeZamani { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<UrunFiyat> UrunFiyats { get; set; }
        public virtual List<UrunGorsel> UrunGorsels { get; set; }

    }
}
