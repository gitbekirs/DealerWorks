using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class Model : ModelBase
    {
        public Model()
        {
            IsDeleted=false;
            EklenmeZamani=DateTime.Now;
            Marka=new Marka();
            Uruns= new List<Urun>();
        }

        public string ModelAdi { get; set; }

        public int MarkaId { get; set; }
        public virtual Marka Marka { get; set; }

        public DateTime EklenmeZamani { get; set; }
        public DateTime? GuncellenmeZamani { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Urun> Uruns { get; set; }


    }
}
