using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Comentario_Model
    {
        public int id { get; set; }
        public string comentario { get; set; }
        public Estudiante_Model estudiante { get; set; }
    }
}