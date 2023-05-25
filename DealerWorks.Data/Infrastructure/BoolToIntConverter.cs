using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace DealerWorks.Data.Infrastructure
{
  
    //mysql db kullanılırsa bu sınıfa TINYINT tipinin entity'de bool tipine dönüştürülebilmesi için ihtiyaç var.
    public class BoolToIntConverter : ValueConverter<bool, int>
    {
        public BoolToIntConverter(ConverterMappingHints mappingHints=null)
            : base(
                v => Convert.ToInt32(v),
                v => Convert.ToBoolean(v),
                mappingHints)
        {
        }

        public static ValueConverterInfo DefaultInfo { get; }
        = new ValueConverterInfo(typeof(bool), typeof(int), i => new BoolToIntConverter(i.MappingHints));
    }
}


//https://www.youtube.com/watch?v=bwN2myXHdos&list=PLjn_v5iA99pkZvq4rvp4tM7unhX1dzlU2&index=5