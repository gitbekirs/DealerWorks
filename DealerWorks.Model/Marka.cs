using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class Marka : ModelBase
    {
        public Marka()
        {
            IsDeleted=false;
            EklenmeZamani=DateTime.Now;
            Models=new List<Model>();
            Uruns = new List<Urun>();
        }

        public string MarkaAdi { get; set; }
        public string MarkaGorselUrl { get; set; }

        public DateTime EklenmeZamani { get; set; }
        public DateTime? GuncellenmeZamani { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Model> Models { get; set; }
        public virtual List<Urun> Uruns { get; set; }

    }
}
