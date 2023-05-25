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
    public class KategoriData : EntityBaseData<Model.Kategori>
    {
        public KategoriData(IOptions<DatabaseSettings> dbOptions):base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
