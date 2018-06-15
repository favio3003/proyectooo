using Microsoft.AspNet.Identity;
using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1._1.Controllers
{
    public class ComentarioController : Controller
    {
        [Authorize]
        // GET: estudianteComentario
        public ActionResult Index()
        {
            return View();
        }

        private ApplicationDbContext _context;

        public ComentarioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize]
        public ActionResult createComentario(Comentario_Model comentario)
        {
            //var estudiante = User.Identity.GetUserId();
            //var estudiante2 = _context.Estudiante.SingleOrDefault(c => c.Registerid == estudiante);
            //comentario.estudiante = estudiante2;
            _context.comentario.Add(comentario);
            _context.SaveChanges();
            return RedirectToAction("perfilPasante", "Home");
            // return View("Index");
        }

        [Authorize]
        public ActionResult editComentario(Comentario_Model coment)
        {
            var comentarioDb = _context.comentario.FirstOrDefault(c => c.id == coment.id);
            if (comentarioDb == null)
                return HttpNotFound();
            comentarioDb.comentario = comentarioDb.comentario;
            _context.SaveChanges();
            return RedirectToAction("perfilPasante", "Home");
        }

        [Authorize]
        public ActionResult deleteComentario(int id)
        {
            var comentario = _context.comentario.FirstOrDefault(c => c.id == id);
            if (comentario.id == id)
            {
                _context.comentario.Remove(comentario);
            }
            _context.SaveChanges();
            return RedirectToAction("perfilPasante", "Home");
        }
    }
}