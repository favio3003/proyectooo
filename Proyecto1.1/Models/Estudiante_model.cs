using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1._1.Models
{
    public class Estudiante_Model
    {
        public int id { get; set; }
        [Display(Name = "Carnet de Identidad")]
        public string ci { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechadenacimiento { get; set; }
        [Display(Name = "Correo electronico")]
        public string correoElectronico { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        public bool esayudante { get; set; }
        public ICollection<Materia_Model> Materia { get; set; }
        public string Registerid { get; set; }
    }
}