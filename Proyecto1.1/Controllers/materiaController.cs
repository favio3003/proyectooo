using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Proyecto1._1.Controllers
{
    public class materiaController : Controller
    {
        private ApplicationDbContext _context;

        public materiaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int Id)
        {
            var mat = _context.Materia.SingleOrDefault(c => c.id == Id);
            if (mat == null)

                return HttpNotFound();

            return View(mat);
        }

        [Authorize]
        public ActionResult createMateria(Materia_Model mat)
        {
            _context.Materia.Add(mat);
            _context.SaveChanges();
            return RedirectToAction("Index", "Materia");
        }

        [Authorize]
        public ActionResult editMateria(int id)
        {
            var mat = _context.Materia.FirstOrDefault(c => c.id == id);
            if (mat == null)
                return HttpNotFound();
            Materia_Model m = new Materia_Model();
            m.nombre = mat.nombre;
            return View("New", "Materia");
        }

        [Authorize]
        public ActionResult deleteMateria(int id)
        {
            var mat = _context.Materia.FirstOrDefault(c => c.id == id);
            if (mat.id == id)
            {
                _context.Materia.Remove(mat);
            }
            return View("Index", "Materia");
        }

    }
}