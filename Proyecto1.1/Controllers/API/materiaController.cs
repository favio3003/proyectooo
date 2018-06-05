using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers.API
{
    public class MateriaController : ApiController
    {
        private ApplicationDbContext _context;
        public MateriaController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Materia_Model> GetMateria()
        {
            return _context.Materia.ToList();
        }
        public Materia_Model GetMateria(int id)
        {
            var customer = _context.Materia.SingleOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Materia_Model CreateMateria(Materia_Model Materia_model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Materia.Add(Materia_model);
            _context.SaveChanges();
            return Materia_model;
        }
        [HttpPut]
        public void UpdateMateria(int id, Materia_Model Materia)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MateriaDb = _context.Materia.SingleOrDefault(c => c.id == id);
            if (MateriaDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            MateriaDb.nombre = Materia.nombre;
            MateriaDb.areaModel = Materia.areaModel;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMateria(int id)
        {
            var MateriaDb = _context.Materia.SingleOrDefault(c => c.id == id);
            if (MateriaDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Materia.Remove(MateriaDb);
            _context.SaveChanges();
        }
    }

}
