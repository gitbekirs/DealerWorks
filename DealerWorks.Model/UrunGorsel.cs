using DealerWorks.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Model
{
    public class UrunGorsel : ModelBase
    {
        public UrunGorsel()
        {
            Isdeleted=false;
            Urun=new Urun();
            GecerlilikTarihi=DateTime.Now.AddYears(1);
            //UrunGorselFile =  new FormFile(Stream.Null, 0, 0, "", "");//test edilecek!....
        }

        public string UrunGorselAciklama { get; set; }
        public string UrunGorselUrl { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        public DateTime GecerlilikTarihi { get; set; }
        public bool Isdeleted { get; set; }
        //public IFormFile UrunGorselFile { get; set; }
    }
}
