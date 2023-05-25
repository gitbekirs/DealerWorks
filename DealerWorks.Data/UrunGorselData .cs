using DealerWorks.Data.Infrastructure;
using DealerWorks.Data.Infrastructure.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Data
{
    public class UrunGorselData : EntityBaseData<Model.UrunGorsel>
    {
        public UrunGorselData(IOptions<DatabaseSettings> dbOptions):base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
