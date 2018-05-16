using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Estudiante_model
    {
        public int id { get; set; }
        public string ci { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechadenacimiento { get; set; }
        public string telefono { get; set; }
        public bool sexo { get; set; }
        public string correoelectronico { get; set; }
        public bool esayudante { get; set; }
    }
}