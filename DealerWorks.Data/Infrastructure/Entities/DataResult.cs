using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Data.Infrastructure.Entities
{
    public class DataResult
    {
        public DataResult(bool _isSucceed, string _message)
        {
            IsSucceed=_isSucceed;
            Message=_message;
        }
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
}


//https://www.youtube.com/watch?v=bwN2myXHdos&list=PLjn_v5iA99pkZvq4rvp4tM7unhX1dzlU2&index=5