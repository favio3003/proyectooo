using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers.API
{
    public class AreaController : ApiController
    {
        private ApplicationDbContext _context;
        public AreaController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Area_Model> GetArea()
        {
            return _context.Area.ToList();
        }
        public Area_Model GetArea(int id)
        {
            var customer = _context.Area.SingleOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Area_Model CreateArea(Area_Model Area_model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Area.Add(Area_model);
            _context.SaveChanges();
            return Area_model;
        }
        [HttpPut]
        public void UpdateArea(int id, Area_Model Area)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var AreaDb = _context.Area.SingleOrDefault(c => c.id == id);
            if (AreaDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            AreaDb.nombre = Area.nombre;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteArea(int id)
        {
            var AreaDb = _context.Area.SingleOrDefault(c => c.id == id);
            if (AreaDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Area.Remove(AreaDb);
            _context.SaveChanges();
        }
    }
}
