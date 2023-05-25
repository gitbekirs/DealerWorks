
namespace DealerWorks.Model.Core
{
    public class ModelBase
    {
        //bütün model classlarında ortak bir alan varsa burada tanımlayıp, model classlarını bu base'den türeterek aynı alanı tekraren yazmaktan kurtuluruz.
        //mesela her tabloda Id adında bir kolon varsa burada tanımlanır.B,r  nevi tablo modellerinin ortak sınıfı


        public int Id { get; set; }
    }
}
