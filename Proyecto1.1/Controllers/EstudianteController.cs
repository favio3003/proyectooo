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
            return View();
        }
        //[Authorize]
        public ActionResult Index()
        {
            var Area = _context.Area.ToList();
            return View(Area);
        }
       // [Authorize]
        public ActionResult Materia(int id)
        {
            var Materia = from m in _context.Materia
                          where m.areaModel.id == id
                          select m;
            return View(Materia);
        }

        public ActionResult pasantesMateria(int id)
        {
            var pasante = from PerfilPasante in _context.materiaEstudiantes
                          where PerfilPasante.Materia_Model.id == id
                          select PerfilPasante.Estudiante_Model;
                return View(pasante);
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

        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Pasantes()
        {
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pasantes(Solicitud_Model sol)
        {
            if(!ModelState.IsValid)
            {
                return View("Pasantes",sol);
            }
            string a = User.Identity.GetUserId();
            var e = _context.Estudiante.SingleOrDefault(c => c.Registerid == a);
            sol.estudiante = e;
            _context.solicitud.Add(sol);
            _context.SaveChanges();
            return RedirectToAction("Index", "Estudiante");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Inicio(Estudiante_Model est)
        {
            if (!ModelState.IsValid)
            {
                return View("Inicio",est);
            }
            else
            {
                est.Registerid = User.Identity.GetUserId();
                _context.Estudiante.Add(est);
                _context.SaveChanges();
                return RedirectToAction("Index", "Estudiante");
            }
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