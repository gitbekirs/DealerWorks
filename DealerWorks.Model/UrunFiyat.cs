using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class UrunFiyat : ModelBase
    {
        public UrunFiyat()
        {
            IsDeleted=false;
            GecerlilikTarihi = DateTime.Now.AddYears(1);
            EklenmeTarihi=DateTime.Now;
            Urun=new Urun();
        }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        public decimal Fiyat { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
