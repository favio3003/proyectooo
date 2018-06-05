using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Proyecto1._1.Controllers.API
{
    public class unidaddeaprendizajeController : ApiController
    {
        private ApplicationDbContext _context;
        public unidaddeaprendizajeController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<unidadDeAprendizaje_Model> GetunidadDeAprendizaje()
        {
            return _context.unidadDeAprendizaje.ToList();
        }

        public unidadDeAprendizaje_Model GetunidadDeAprendizaje(int id)
        {
            var unidaddeaprendizaje = _context.unidadDeAprendizaje.SingleOrDefault(a => a.id == id);
            if (unidaddeaprendizaje == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return unidaddeaprendizaje;
        }

        [HttpPost]
        public unidadDeAprendizaje_Model CreateunidadDeAprendizaje(unidadDeAprendizaje_Model unidadDeAprendizaje)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.unidadDeAprendizaje.Add(unidadDeAprendizaje);
            _context.SaveChanges();
            return unidadDeAprendizaje;
        }

        [HttpPut]
        public void UpdateunidadDeAprendizaje(int id, unidadDeAprendizaje_Model unidadDeAprendizaje_Model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var unidaddeaprendizajeDb = _context.unidadDeAprendizaje.SingleOrDefault(c => c.id == id);
            if (unidaddeaprendizajeDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            unidaddeaprendizajeDb.nombre = unidadDeAprendizaje_Model.nombre;
            unidaddeaprendizajeDb.idMateria = unidadDeAprendizaje_Model.idMateria;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteunidadDeAprendizaje(int id)
        {
            var unidaddeaprendizajeDb = _context.unidadDeAprendizaje.SingleOrDefault(c => c.id == id);
            if (unidaddeaprendizajeDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.unidadDeAprendizaje.Remove(unidaddeaprendizajeDb);
            _context.SaveChanges();
        }
    }
}