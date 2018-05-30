using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class NewEstudianteWithRegister
    {
        public Estudiante_Model Estudiantes { get; set; }
        public RegisterViewModel Register { get; set; }
    }
}