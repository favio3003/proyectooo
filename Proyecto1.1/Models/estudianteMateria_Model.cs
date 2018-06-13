using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class estudianteMateria_Model
    {
        [Key, Column(Order = 0)]
        public int estudianteId { get; set; }
        [Key, Column(Order = 1)]
        public int materiaId { get; set; }

        public virtual Estudiante_Model est { get; set; }
        public virtual Materia_Model materia { get; set; }
        public float calificacion { get; set; }
        public string comentario { get; set; }
    }
}