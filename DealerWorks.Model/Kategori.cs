using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class Kategori: ModelBase
    {
        public Kategori()
        {
            IsDeleted=false;
            EklenmeZamani=DateTime.Now;
            Uruns= new List<Urun>();
        }

        public string KategoriAdi { get; set; }
        public string KategoriGorselUrl { get; set; }

        public DateTime EklenmeZamani { get; set; }
        public DateTime? GuncellenmeZamani { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Urun> Uruns { get; set; }

    }
}
