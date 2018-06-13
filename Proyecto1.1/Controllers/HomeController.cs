using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1._1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult perfilPasante(int id)
        {
            var perfil = from perfil1 in _context.Estudiante where perfil1.id == id orderby perfil1.apellido
                         select perfil1;
            return View(perfil);
        }


        public ActionResult ListaPasantes()
        {
            var lista = _context.Estudiante.ToList();
            return View(lista);
        }

        public ActionResult Condiciones ()
        {
            ViewBag.Message = "Terminos y Condiciones";
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}