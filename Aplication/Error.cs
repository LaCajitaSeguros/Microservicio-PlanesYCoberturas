using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class Error
    {
        public Error(string mensaje)
        {
            Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
    }
}
