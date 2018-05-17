using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers
{
    public class pasanteController : ApiController
    {
        private ApplicationDbContext _context;
        public pasanteController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /API/Pasante
        public IEnumerable<Pasante_Model> GetPasante_()
        {
            return _context.Pasante.ToList();
        }
        //GET /API/Pasante/1
        public Pasante_Model GetPasante(int id)
        {
            var pasante = _context.Pasante.SingleOrDefault(i => i.id == id);
            if (pasante == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return pasante;
        }
        [HttpPost]
        //POST /API/Pasantes
        public void createPasante(Pasante_Model pas)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Pasante.Add(pas);
            _context.SaveChanges();
        }
        [HttpPut]
        //PUT /API/Pasantes
        public void updatePasante(Pasante_Model pas)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var pasante = _context.Pasante.SingleOrDefault(c => c.id == pas.id);
            pasante.telefono = pas.telefono;
            pasante.descripcion = pas.descripcion;
            pasante.imagen = pas.imagen;
            pasante.horario = pas.horario;
        }
        [HttpDelete]
        //DELETE /API/Pasante/1
        public void deletePasante(int id)
        {
            var pasanteInDb = _context.Pasante.SingleOrDefault(c => c.id == id);
            if (pasanteInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Pasante.Remove(pasanteInDb);
            _context.SaveChanges();
        }
    }
}
