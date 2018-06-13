using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1._1.Controllers
{
    public class estudianteMateriaController : Controller
    {
        // GET: estudianteArea
        public ActionResult Index()
        {
            return View();
        }

        private ApplicationDbContext _context;

        public estudianteMateriaController()
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
        public ActionResult EstudianteView()
        {
            return View();
        }

        public ActionResult createEstudianteArea(estudianteMateria_Model estAr)
        {
            _context.EstudiateMateria.Add(estAr);
            _context.SaveChanges();
            return RedirectToAction("", "");
            // return View("Index");
        }

        [Authorize]
        public ActionResult editEstudianteMateria(estudianteMateria_Model estudianteMat)
        {
            var estudianteMatDb = _context.EstudiateMateria.FirstOrDefault(c => c.estudianteId == estudianteMat.estudianteId && c.materiaId == estudianteMat.materiaId);
            if (estudianteMatDb == null)
                return HttpNotFound();
            estudianteMatDb.calificacion = estudianteMat.calificacion;
            estudianteMatDb.comentario = estudianteMat.comentario;
            _context.SaveChanges();
            return View("", "");
        }

        [Authorize]
        public ActionResult deleteEstudianteMateria(estudianteMateria_Model estudianteMat)
        {
            var estudianteMatDb = _context.EstudiateMateria.FirstOrDefault(c => c.estudianteId == estudianteMat.estudianteId && c.materiaId == estudianteMat.materiaId);
            if (estudianteMatDb.estudianteId == estudianteMat.estudianteId && estudianteMatDb.materiaId == estudianteMat.materiaId)
            {
                _context.EstudiateMateria.Remove(estudianteMatDb);
            }
            _context.SaveChanges();
            return View("", "");
        }

    }
}