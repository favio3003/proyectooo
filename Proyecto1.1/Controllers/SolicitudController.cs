using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1._1.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        private ApplicationDbContext _context;

        public SolicitudController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            var sol = _context.solicitud.SingleOrDefault(c => c.id == Id);
            if (sol == null)

                return HttpNotFound();

            return View(sol);
        }

        [Authorize]
        public ActionResult createSolicitud(Solicitud_Model sol)
        {
            _context.solicitud.Add(sol);
            _context.SaveChanges();
            return RedirectToAction("Index", "Solicitud");
        }

        [Authorize]
        public ActionResult editSolicitud(int id)
        {
            var sol = _context.solicitud.FirstOrDefault(c => c.id == id);
            if (sol == null)
                return HttpNotFound();
            Solicitud_Model s = new Solicitud_Model();
            s.descripcion = sol.descripcion;
            s.estudiante = sol.estudiante;
            return View("New", "Solicitud");
        }

        [Authorize]
        public ActionResult deleteSolicitud(int id)
        {
            var sol = _context.solicitud.FirstOrDefault(c => c.id == id);
            if (sol.id == id)
            {
                _context.solicitud.Remove(sol);
            }
            return View("Index", "Solicitud");
        }

    }
}