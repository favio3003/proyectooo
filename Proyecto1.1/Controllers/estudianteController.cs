using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers
{
    public class estudianteController : ApiController
    {
        private ApplicationDbContext _context;
        public estudianteController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /API/Estudiante
        public IEnumerable<Estudiante_Model> GetEstudiante_()
        {
            return _context.Estudiante.ToList();
        }
        //GET /API/Estudiante/1
        public Estudiante_Model GetEstudiante(int id)
        {
            var estudiante = _context.Estudiante.SingleOrDefault(i => i.id == id);
            if (estudiante == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return estudiante;
        }
        [HttpPost]
        //POST /API/Estudiantes
        public void createEstudiante(Estudiante_Model est)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Estudiante.Add(est);
            _context.SaveChanges();
        }
        [HttpPut]
        //PUT /API/Estudiantes
        public void updateEstudainte(Estudiante_Model est)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var estudiante = _context.Estudiante.SingleOrDefault(c => c.id == est.id);
            estudiante.ci = est.ci;
            estudiante.nombre = est.nombre;
            estudiante.apellido = est.apellido;
            estudiante.fechadenacimiento = est.fechadenacimiento;
            estudiante.telefono = est.telefono;
            estudiante.sexo = est.sexo;
            estudiante.correoelectronico = est.correoelectronico;
            estudiante.esayudante = est.esayudante;
        }
        [HttpDelete]
        //DELETE /API/tudiante/1
        public void deleteEstudiante(int id)
        {
            var estudianteInDb = _context.Estudiante.SingleOrDefault(c => c.id == id);
            if (estudianteInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Estudiante.Remove(estudianteInDb );
            _context.SaveChanges();
        }
    }
}
