using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Response
    {
        public string Message { get; set; }
        public bool HasSuccess { get; set; }
        public Exception Exception { get; set; }
    }
}
