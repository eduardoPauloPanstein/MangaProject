﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SingleResponse<T> : Response
    {
        public SingleResponse(string message, bool hasSuccess,T item,Exception? ex) : base(message, hasSuccess, ex)
        {
           this.Data = item;
        }

        public T Data { get; set; }
    }
}
