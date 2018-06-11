using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1._1.Models
{
    public class VistaMateriaArea_Model
    {
        public virtual Area_Model Area { get; set; }
        public virtual Materia_Model Materia { get; set; }
        public virtual unidadDeAprendizaje_Model UnidadDeAprendizaje { get; set; }


    }
}