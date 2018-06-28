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
        [Required(ErrorMessage = "Otros?")]
        public int id { get; set; }
       
        [Display(Name = "Carnet de Identidad")]
        [Required(ErrorMessage = "Ingrese un carnet")]
      
        public string ci { get; set; }
        [Display(Name = "Nombre")]
        [Required (ErrorMessage = "Todos tienen nombre")]
        [RegularExpression("^[A-ZÑÁÉÍÓÚa-z   ]+$", ErrorMessage = "Porfavor Ingrese Letras")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Todos tienen Apellido")]
       [RegularExpression("^[A-ZÑÁÉÍÓÚa-z   ]+$", ErrorMessage = "Porfavor Ingrese Letras")]
        public string apellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
      
        [Required(ErrorMessage = "Ingresa una fecha de nacimiento")]
        public DateTime fechadenacimiento { get; set; }
        [Required(ErrorMessage = "Necesito registrar tu telefono")]
        [Display(Name = "Telefono")]
        [RegularExpression("^[+ 0-9]+$", ErrorMessage = "Porfavor Ingrese solamente numeros")]
        // [Required(ErrorMessage = "Nada de anónimos.")]
        public string telefono { get; set; }
        [Display(Name = "Sexo")]       
        public string sexo { get; set; }
        [Required]
        public bool esayudante { get; set; }

        public ICollection<Materia_Model> Materia { get; set; }
        public string Registerid { get; set; }
    }
}