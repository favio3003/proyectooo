using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers.API
{
    public class EstudianteController : ApiController
    {
        private ApplicationDbContext _context;
        public EstudianteController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Estudiante_Model> GetEstudiante()
        {
            return _context.Estudiante.ToList();
        }
        public Estudiante_Model GetEstudiante(int id)
        {
            var customer = _context.Estudiante.SingleOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Estudiante_Model CreateEstudiante(Estudiante_Model Estudiante_model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Estudiante.Add(Estudiante_model);
            _context.SaveChanges();
            return Estudiante_model;
        }
        [HttpPut]
        public void UpdateEstudiante(int id, Estudiante_Model estudiante)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var estudianteDb = _context.Estudiante.SingleOrDefault(c => c.id == id);
            if (estudianteDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            estudianteDb.ci = estudiante.ci;
            estudianteDb.nombre = estudiante.nombre;
            estudianteDb.apellido = estudiante.apellido;
            estudianteDb.fechadenacimiento = estudiante.fechadenacimiento;
            estudianteDb.telefono = estudiante.telefono;
            estudianteDb.sexo = estudiante.sexo;
          
            estudianteDb.esayudante = estudiante.esayudante;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteEstudiante(int id)
        {
            var EstudianteDb = _context.Estudiante.SingleOrDefault(c => c.id == id);
            if (EstudianteDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Estudiante.Remove(EstudianteDb);
            _context.SaveChanges();
        }
    }
}
