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
    public class tblViajesViajerosController : ApiController
    {
        private AgenciadeViajeEntities db = new AgenciadeViajeEntities();

        // GET: api/tblViajesViajeros
        public IQueryable<tblViajesViajeros> GettblViajesViajeros()
        {
            return db.tblViajesViajeros;
        }

        // GET: api/tblViajesViajeros/5
        [ResponseType(typeof(tblViajesViajeros))]
        public IHttpActionResult GettblViajesViajeros(int id)
        {
            tblViajesViajeros tblViajesViajeros = db.tblViajesViajeros.Find(id);
            if (tblViajesViajeros == null)
            {
                return NotFound();
            }

            return Ok(tblViajesViajeros);
        }

        // PUT: api/tblViajesViajeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblViajesViajeros(int id, tblViajesViajeros tblViajesViajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblViajesViajeros.IdViajes)
            {
                return BadRequest();
            }

            db.Entry(tblViajesViajeros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblViajesViajerosExists(id))
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

        // POST: api/tblViajesViajeros
        [ResponseType(typeof(tblViajesViajeros))]
        public IHttpActionResult PosttblViajesViajeros(tblViajesViajeros tblViajesViajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblViajesViajeros.Add(tblViajesViajeros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblViajesViajerosExists(tblViajesViajeros.IdViajes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblViajesViajeros.IdViajes }, tblViajesViajeros);
        }

        // DELETE: api/tblViajesViajeros/5
        [ResponseType(typeof(tblViajesViajeros))]
        public IHttpActionResult DeletetblViajesViajeros(int id)
        {
            tblViajesViajeros tblViajesViajeros = db.tblViajesViajeros.Find(id);
            if (tblViajesViajeros == null)
            {
                return NotFound();
            }

            db.tblViajesViajeros.Remove(tblViajesViajeros);
            db.SaveChanges();

            return Ok(tblViajesViajeros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblViajesViajerosExists(int id)
        {
            return db.tblViajesViajeros.Count(e => e.IdViajes == id) > 0;
        }
    }
}