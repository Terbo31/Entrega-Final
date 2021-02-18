using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgenciaAPI.Models;

namespace AgenciaAPI.Controllers
{
    public class tblViajesController : ApiController
    {
        private AgenciadeViajeEntities db = new AgenciadeViajeEntities();

        // GET: api/tblViajes
        public IQueryable<tblViajes> GettblViajes()
        {
            return db.tblViajes;
        }

        // GET: api/tblViajes/5
        [ResponseType(typeof(tblViajes))]
        public IHttpActionResult GettblViajes(int id)
        {
            tblViajes tblViajes = db.tblViajes.Find(id);
            if (tblViajes == null)
            {
                return NotFound();
            }

            return Ok(tblViajes);
        }

        // PUT: api/tblViajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblViajes(int id, tblViajes tblViajes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblViajes.CodigoViaje)
            {
                return BadRequest();
            }

            db.Entry(tblViajes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblViajesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblViajes
        [ResponseType(typeof(tblViajes))]
        public IHttpActionResult PosttblViajes(tblViajes tblViajes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblViajes.Add(tblViajes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblViajesExists(tblViajes.CodigoViaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblViajes.CodigoViaje }, tblViajes);
        }

        // DELETE: api/tblViajes/5
        [ResponseType(typeof(tblViajes))]
        public IHttpActionResult DeletetblViajes(int id)
        {
            tblViajes tblViajes = db.tblViajes.Find(id);
            if (tblViajes == null)
            {
                return NotFound();
            }

            db.tblViajes.Remove(tblViajes);
            db.SaveChanges();

            return Ok(tblViajes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblViajesExists(int id)
        {
            return db.tblViajes.Count(e => e.CodigoViaje == id) > 0;
        }
    }
}