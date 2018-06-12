using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace Proyecto1._1.Controllers
{
    public class EstudianteController : Controller
    {
        private ApplicationDbContext _context;

        public EstudianteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Lista()
        {
            var Estudiante = _context.Estudiante.ToList();
            return View(Estudiante);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
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
        
        public ActionResult createEstudiante(Estudiante_Model est)
        {
            est.Registerid = User.Identity.GetUserId();
            _context.Estudiante.Add(est);
            _context.SaveChanges();
            return RedirectToAction("Index", "Estudiante");
           // return View("Index");
        }

        [Authorize]
        public ActionResult editEstudiante(Estudiante_Model estudiante)
        {
            var estudianteDb = _context.Estudiante.FirstOrDefault(c => c.id == estudiante.id);
            if (estudianteDb == null)
                return HttpNotFound();
            estudianteDb.ci = estudiante.ci;
            estudianteDb.nombre = estudiante.nombre;
            estudianteDb.apellido = estudiante.apellido;
            estudianteDb.fechadenacimiento = estudiante.fechadenacimiento;
            estudianteDb.telefono = estudiante.telefono;
            estudianteDb.sexo = estudiante.sexo;
            _context.SaveChanges();
            return View("New", "Estudiante");
        }
        /*public ActionResult Pasante(int id)
        {
            var est = _context.Estudiante.FirstOrDefault(c => c.id == id);
            if (est == null)
                return HttpNotFound();
            Estudiante_Model e = new Estudiante_Model();
            e.telefono = est.telefono;
            return View("New", "Estudiante");
        }*/

        [Authorize]
        public ActionResult deleteEstudiante(int id)
        {
            var est = _context.Estudiante.FirstOrDefault(c => c.id == id);
            if (est.id == id)
            {
                _context.Estudiante.Remove(est);
            }
            _context.SaveChanges();
            return View("Index", "Estudiante");
        }

    }
}