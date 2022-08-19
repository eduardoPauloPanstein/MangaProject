using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Response
    {
        public Response(string message, bool hasSuccess,Exception ex)
        {
            Message = message;
            HasSuccess = hasSuccess;
            Exception = ex;
        }

        public string Message { get; set; }
        public bool HasSuccess { get; set; }
        public Exception? Exception { get; set; }
    }
}
