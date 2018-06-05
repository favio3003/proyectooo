using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Solicitud_Model
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Estudiante_Model estudiante { get; set; }
    }
}