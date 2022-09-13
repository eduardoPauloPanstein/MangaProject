using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class SingleResponseWToken<T> : SingleResponse<T>
    {
        public SingleResponseWToken(string message, bool hasSuccess, T item, string token, Exception? ex) : base(message, hasSuccess, item, ex)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
