using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class unidadDeAprendizaje_Model
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Materia_Model idMateria { get; set; }
    }
}