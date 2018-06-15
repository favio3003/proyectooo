using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class Comentario_Model
    {
        public int id { get; set; }
        [Display(Name = "Comentario")]
        [Required(ErrorMessage = "Ingrese un comentario")]
        public string comentario { get; set; }
    }
}