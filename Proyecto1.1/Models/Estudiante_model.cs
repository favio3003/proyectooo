using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Estudiante_Model
    {
        public int id { get; set; }
        public string ci { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechadenacimiento { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Sexo")]
        public bool sexo { get; set; }
        
        public bool esayudante { get; set; }
        public ICollection<Area_Model> Area { get; set; }
    }
}