using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Solicitud_Model
    {
        public int id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Tiene que seguir el ejemplo")]
        public string descripcion { get; set; }
        public Estudiante_Model estudiante { get; set; }
        public Materia_Model materia { get; set; }
    }
}