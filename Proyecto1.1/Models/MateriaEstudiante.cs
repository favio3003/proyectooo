using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class MateriaEstudiante
    {
        public int id { get; set; }
        public Materia_Model Materia_Model { get; set; }
        public Estudiante_Model Estudiante_Model { get; set; }
    }
}