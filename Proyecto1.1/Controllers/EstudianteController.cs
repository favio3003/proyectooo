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
        [Authorize]
        public ActionResult Index()
        {
            var correo = User.Identity.GetUserId();
            var estudiante = _context.Estudiante.SingleOrDefault(c => c.Registerid == correo);
            if (estudiante == null)
            {
                return RedirectToAction("Inicio", "Estudiante");
            }
            var Area = _context.Area.ToList();
            return View(Area);
        }
       [Authorize]
        public ActionResult Materia(int id)
        {
            var Materia = from m in _context.Materia
                          where m.areaModel.id == id
                          select m;
            return View(Materia);
        }
        [Authorize]
        public ActionResult pasantesMateria(int id)
        {
            var pasante = from PerfilPasante in _context.materiaEstudiantes
                          where PerfilPasante.Materia_Model.id == id
                          select PerfilPasante.Estudiante_Model;
                return View(pasante);
        }
        [Authorize]
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
        [Authorize]
        public ActionResult Inicio()
        {
            return View();
        }
        [Authorize]
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
            var user = User.Identity.GetUserId();
            var estudianteDb = _context.Estudiante.SingleOrDefault(c => c.Registerid == user);
            if (!ModelState.IsValid)
            {
                return View("Inicio", est);
            }
            else
            {
                if (estudianteDb == null)
                {
                    est.Registerid = user;
                    _context.Estudiante.Add(est);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Estudiante");
                }
                else
                {
                    if (estudianteDb == null)
                        return HttpNotFound();
                    estudianteDb.ci = est.ci;
                    estudianteDb.nombre = est.nombre;
                    estudianteDb.apellido = est.apellido;
                    estudianteDb.fechadenacimiento = est.fechadenacimiento;
                    estudianteDb.telefono = est.telefono;
                    estudianteDb.sexo = est.sexo;
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
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
        public ActionResult Editar()
        {
            var user = User.Identity.GetUserId();
            if (user == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var estudiante = _context.Estudiante.SingleOrDefault(c => c.Registerid == user);
            if (estudiante == null)
            {
                return RedirectToAction("Inicio", "Estudiante");
            }
            var viewModel = new Estudiante_Model()
            {
                nombre = estudiante.nombre,
                apellido = estudiante.apellido,
                ci = estudiante.ci,
                sexo = estudiante.sexo,
                telefono = estudiante.telefono,
                fechadenacimiento = estudiante.fechadenacimiento
            };
            return View("Inicio", viewModel);
        }
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