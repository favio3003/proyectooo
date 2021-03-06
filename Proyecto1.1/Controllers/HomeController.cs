﻿using Microsoft.AspNet.Identity;
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
        [Authorize]
        public ActionResult perfilPasante(int id)
        {
            var perfil = from perfil1 in _context.Estudiante where perfil1.id == id orderby perfil1.apellido
                         select perfil1;
            return View(perfil);
        }

        [Authorize]
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
        public ActionResult inicio()
        {
            ViewBag.Message = "Desea ser pasante?";
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

        [Authorize]
        public ActionResult Comentario()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comentario(Comentario_Model comentario_Model)
        {
            if(!ModelState.IsValid)
            {
                return View("Comentario", comentario_Model);
            }
            _context.comentario.Add(comentario_Model);
            _context.SaveChanges();
            return RedirectToAction("dejarComentario", "Home");
        }
   
        public ActionResult dejarComentario()
        {
            var comentario = from comen in _context.comentario
                             select comen;
            return View(comentario);
        }
    }
}