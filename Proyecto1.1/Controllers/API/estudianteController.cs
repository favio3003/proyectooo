using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Proyecto1._1.Controllers
{
    public class estudianteController : Controller
    {
        private ApplicationDbContext _context;

        public estudianteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int Id)
        {
            var est = _context.Estudiante.SingleOrDefault(c => c.id == Id);
            if (est == null)

                return HttpNotFound();

            return View(est);
        }

        [Authorize]
        public ActionResult createEstudainte(Estudiante_Model est)
        {
            _context.Estudiante.Add(est);
            _context.SaveChanges();
            return RedirectToAction("Index", "Estudiante");
        }

        [Authorize]
        public ActionResult editEstudiante(int id)
        {
            var est = _context.Estudiante.FirstOrDefault(c => c.id == id);
            if (est == null)
                return HttpNotFound();
            Estudiante_Model e = new Estudiante_Model();
            e.ci = est.ci;
            e.nombre = est.nombre;
            e.apellido = est.apellido;
            e.fechadenacimiento = est.fechadenacimiento;
            e.telefono = est.telefono;
            e.sexo = est.sexo;
            e.correoelectronico = est.correoelectronico;
            e.esayudante = est.esayudante;
            return View("New", "Estudiante");
        }

        [Authorize]
        public ActionResult deleteEstudiante(int id)
        {
            var est = _context.Estudiante.FirstOrDefault(c => c.id == id);
            if (est.id == id)
            {
                _context.Estudiante.Remove(est);
            }
            return View("Index", "Estudiante");
        }

    }
}
