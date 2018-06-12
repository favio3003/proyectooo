using Microsoft.AspNet.Identity;
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
            string a = User.Identity.GetUserId();
            var e = _context.Estudiante.SingleOrDefault(c => c.Registerid == a);
            if (e == null)
                return HttpNotFound();
            sol.estudiante = e;
            e.telefono = sol.telefono;
            _context.solicitud.Add(sol);
            _context.SaveChanges();
            return RedirectToAction("Index", "Estudiante");
        }

        [Authorize]
        public ActionResult editSolicitud(Solicitud_Model solicitud)
        {
            var sol = _context.solicitud.FirstOrDefault(c => c.id == solicitud.id);
            if (sol == null)
                return HttpNotFound();
            sol.descripcion = solicitud.descripcion;
            sol.estudiante = solicitud.estudiante;
            _context.SaveChanges();
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
            _context.SaveChanges();
            return View("Index", "Solicitud");
        }

    }
}