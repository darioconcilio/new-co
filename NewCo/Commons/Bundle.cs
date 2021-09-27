using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Commons
{
    public class Bundle
    {
        public Bundle()
        {

        }

        public Bundle(bool result, string message)
        {
            Result = result;
            Message = message;
        }

        public Bundle(bool result, string message, object value)
        {
            Result = result;
            Message = message;
            Value = value;
        }

        public bool Result { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }
    }
}
