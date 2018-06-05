using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers
{
    public class materiaController : ApiController
    {
        private ApplicationDbContext _context;
        public materiaController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /API/Materias
        public IEnumerable<Materia_Model> GetMateria_()
        {
            return _context.Materia.ToList();
        }
        //GET /API/MAteria/1
        public Materia_Model GetMateria(int id)
        {
            var materia = _context.Materia.SingleOrDefault(i => i.id == id);
            if (materia == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return materia;
        }
        [HttpPost]
        //POST /API/Materias
        public void createMateria(Materia_Model mat)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Materia.Add(mat);
            _context.SaveChanges();
        }
        [HttpPut]
        //PUT /API/Materias
        public void updateArea(Materia_Model mat)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var materia = _context.Materia.SingleOrDefault(c => c.id == mat.id);
            materia.nombre = mat.nombre;
        }
        [HttpDelete]
        //DELETE /API/Materia/1
        public void deleteMateria(int id)
        {
            var materiaInDb = _context.Materia.SingleOrDefault(c => c.id == id);
            if (materiaInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Materia.Remove(materiaInDb);
            _context.SaveChanges();
        }
    }
}
