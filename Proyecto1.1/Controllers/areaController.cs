using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers
{
    public class areaController : ApiController
    {
        private ApplicationDbContext _context;
        public areaController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /API/Areas
        public IEnumerable<Area_Model> GetArea_()
        {
            return _context.Area.ToList();
        }
        //GET /API/Area/1
        public Area_Model GetArea(int id)
        {
            var area = _context.Area.SingleOrDefault(i => i.id == id);
            if (area == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return area;
        }
        [HttpPost]
        //POST /API/Areas
        public void createArea(Area_Model ar)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Area.Add(ar);
            _context.SaveChanges();
        }
        [HttpPut]
        //PUT /API/Areas
        public void updateArea(Area_Model ar)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var area = _context.Area.SingleOrDefault(c => c.id == ar.id);
            area.nombre = ar.nombre;
        }
        [HttpDelete]
        //DELETE /API/Area/1
        public void deleteArea(int id)
        {
            var areaInDb = _context.Area.SingleOrDefault(c => c.id == id);
            if (areaInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Area.Remove(areaInDb);
            _context.SaveChanges();
        }
    }
}
