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
    public class tblViajerosController : ApiController
    {
        private AgenciadeViajeEntities db = new AgenciadeViajeEntities();

        // GET: api/tblViajeros
        public IQueryable<tblViajeros> GettblViajeros()
        {
            return db.tblViajeros;
        }

        // GET: api/tblViajeros/5
        [ResponseType(typeof(tblViajeros))]
        public IHttpActionResult GettblViajeros(int id)
        {
            tblViajeros tblViajeros = db.tblViajeros.Find(id);
            if (tblViajeros == null)
            {
                return NotFound();
            }

            return Ok(tblViajeros);
        }

        // PUT: api/tblViajeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblViajeros(int id, tblViajeros tblViajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblViajeros.Cedula)
            {
                return BadRequest();
            }

            db.Entry(tblViajeros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblViajerosExists(id))
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

        // POST: api/tblViajeros
        [ResponseType(typeof(tblViajeros))]
        public IHttpActionResult PosttblViajeros(tblViajeros tblViajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblViajeros.Add(tblViajeros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblViajerosExists(tblViajeros.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblViajeros.Cedula }, tblViajeros);
        }

        // DELETE: api/tblViajeros/5
        [ResponseType(typeof(tblViajeros))]
        public IHttpActionResult DeletetblViajeros(int id)
        {
            tblViajeros tblViajeros = db.tblViajeros.Find(id);
            if (tblViajeros == null)
            {
                return NotFound();
            }

            db.tblViajeros.Remove(tblViajeros);
            db.SaveChanges();

            return Ok(tblViajeros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblViajerosExists(int id)
        {
            return db.tblViajeros.Count(e => e.Cedula == id) > 0;
        }
    }
}