using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Proyecto1._1.Controllers
{
    public class UnidadDeAprendizajeController : Controller
    {
        private ApplicationDbContext _context;

        public UnidadDeAprendizajeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int Id)
        {
            var uap = _context.unidadDeAprendizaje.SingleOrDefault(c => c.id == Id);
            if (uap == null)

                return HttpNotFound();

            return View(uap);
        }

        [Authorize]
        public ActionResult createUnidadDeAprendizaje(unidadDeAprendizaje_Model uap)
        {
            _context.unidadDeAprendizaje.Add(uap);
            _context.SaveChanges();
            return RedirectToAction("Index", "UnidadDeAprendizaje");
        }

        [Authorize]
        public ActionResult editUnidadDeAprendizaje(int id)
        {
            var uap = _context.unidadDeAprendizaje.FirstOrDefault(c => c.id == id);
            if (uap == null)
                return HttpNotFound();
            unidadDeAprendizaje_Model unap = new unidadDeAprendizaje_Model();
            unap.nombre = uap.nombre;
            unap.idMateria = uap.idMateria;
            return View("New", "UnidadDeAprendizaje");
        }

        [Authorize]
        public ActionResult deleteUnidadDeAprendizaje(int id)
        {
            var uap = _context.unidadDeAprendizaje.FirstOrDefault(c => c.id == id);
            if (uap.id == id)
            {
                _context.unidadDeAprendizaje.Remove(uap);
            }
            return View("Index", "UnidadDeAprendizaje");
        }

    }
}