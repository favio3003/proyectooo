using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Proyecto1._1.Controllers
{
    public class AreaController : Controller
    {
        private ApplicationDbContext _context;

        public AreaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Area_vistaPartial()
        {
            var Area = _context.Area.ToList();
            return View(Area);
           
        }

        public ActionResult Details(int Id)
        {
            var area = _context.Area.SingleOrDefault(c => c.id == Id);
            if (area == null)

                return HttpNotFound();

            return View(area);
        }

        [Authorize]
        public ActionResult createArea(Area_Model area)
        {
            _context.Area.Add(area);
            _context.SaveChanges();
            return RedirectToAction("Index", "Area");
        }

        [Authorize]
        public ActionResult editArea(Area_Model ar)
        {
            var area = _context.Area.FirstOrDefault(c => c.id == ar.id);
            if (area == null)
                return HttpNotFound();
            area.nombre = ar.nombre;
            _context.SaveChanges();
            return View("New", "Area");
        }

        [Authorize]
        public ActionResult deleteArea(int id)
        {
            var area = _context.Area.FirstOrDefault(c => c.id == id);
            if (area.id == id)
            {
                _context.Area.Remove(area);
            }
            _context.SaveChanges();
            return View("Index", "Area");
        }

    }
}