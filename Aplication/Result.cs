using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class Result
    {
        public Result(object data, HttpStatusCode httpStatusCode)
        {
            Data = data;
            HttpStatusCode = httpStatusCode;
        }

        public object Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
