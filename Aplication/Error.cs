using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class Error
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public static Error Conflict(string message)
        {
            return new Error
            {
                Message = message,
                HttpStatusCode = HttpStatusCode.Conflict
            };
        }

        public static Error BadRequest(string message)
        {
            return new Error
            {
                Message = message,
                HttpStatusCode = HttpStatusCode.BadRequest
            };
        }

        public static Error NotFound(string message)
        {
            return new Error
            {
                Message = message,
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
