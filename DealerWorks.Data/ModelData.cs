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
    public class ModelData : EntityBaseData<Model.Model>
    {
        public ModelData(IOptions<DatabaseSettings> dbOptions):base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
