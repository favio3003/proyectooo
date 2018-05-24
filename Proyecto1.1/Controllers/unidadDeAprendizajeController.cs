using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers
{
    public class unidadDeAprendizajeController : ApiController
    {
        private ApplicationDbContext _context;
        public unidadDeAprendizajeController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /API/unidadDeAprendizajes
        public IEnumerable<unidadDeAprendizaje_Model> GetUnidadDeAprendizaje_()
        {
            return _context.unidadDeAprendizaje.ToList();
        }
        //GET /API/unidadDeAprendizajeController/1
        public unidadDeAprendizaje_Model GetunidadDeAprendizaje(int id)
        {
            var uap = _context.unidadDeAprendizaje.SingleOrDefault(i => i.id == id);
            if (uap == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return uap;
        }
        [HttpPost]
        //POST /API/unidadDeAprendizajes
        public void createunidadDeAprendizaje(unidadDeAprendizaje_Model uaprendizaje)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.unidadDeAprendizaje.Add(uaprendizaje);
            _context.SaveChanges();
        }
        [HttpPut]
        //PUT /API/unidadDeAprendizajes
        public void updateUnidadDeAprendizaje(unidadDeAprendizaje_Model uaprendizaje)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var uap = _context.unidadDeAprendizaje.SingleOrDefault(c => c.id == uaprendizaje.id);
            uap.nombre = uaprendizaje.nombre;
            uap.idMateria = uaprendizaje.idMateria;
        }
        [HttpDelete]
        //DELETE /API/unidadDeAprendizaje/1
        public void deleteUnidadDeAprendizaje(int id)
        {
            var uapInDb = _context.unidadDeAprendizaje.SingleOrDefault(c => c.id == id);
            if (uapInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.unidadDeAprendizaje.Remove(uapInDb);
            _context.SaveChanges();
        }
    }
}
