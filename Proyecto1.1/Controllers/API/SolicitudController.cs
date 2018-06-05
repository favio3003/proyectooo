using Proyecto1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1._1.Controllers.API
{
    public class SolicitudController : ApiController
    {
        private ApplicationDbContext _context;
        public SolicitudController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Solicitud_Model> GetSolicitud()
        {
            return _context.solicitud.ToList();
        }
        public Solicitud_Model GetSolicitud(int id)
        {
            var customer = _context.solicitud.SingleOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Solicitud_Model CreateSolicitud(Solicitud_Model solicitud_model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.solicitud.Add(solicitud_model);
            _context.SaveChanges();
            return solicitud_model;
        }
        [HttpPut]
        public void UpdateSolicitud(int id,Solicitud_Model customerDtos)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerDb = _context.solicitud.SingleOrDefault(c => c.id == id);
            if (customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            /* customerDb.nombre = customer.nombre;
             customerDb.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
              customerDb.MembershipTypeId = custo                       mer.MembershipTypeId; */
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var solicitudDb = _context.solicitud.SingleOrDefault(c => c.id == id);
            if (solicitudDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.solicitud.Remove(solicitudDb);
            _context.SaveChanges();
        }
    }
}
