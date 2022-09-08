using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class DataResponse<T> : Response
    {
        public DataResponse(string message, bool hasSuccess, List<T> dados, Exception? ex) : base(message, hasSuccess, ex)
        {
            Data = dados;
        }

        public List<T> Data { get; set; }
    }
}
