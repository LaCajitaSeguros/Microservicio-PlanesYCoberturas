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
        public object Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public static Result SuccessOk(object data)
        {
            return new Result
            {
                Data = data,
                HttpStatusCode = HttpStatusCode.OK
            };
        }

        public static Result SuccessCreated(object data)
        {
            return new Result
            {
                Data = data,
                HttpStatusCode = HttpStatusCode.Created
            };
        }

        public static Result Error(Error data)
        {
            return new Result
            {
                Data = data,
                HttpStatusCode = data.HttpStatusCode
            };
        }
    }
}
