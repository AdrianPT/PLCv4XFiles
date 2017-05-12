using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PLCv4XFiles.Models;

namespace PLCv4XFiles.Controllers
{
    public class z_PLC_ContadorController : ApiController
    {
        private PLCv4XFilesContext db = new PLCv4XFilesContext();

        // GET: api/z_PLC_Contador
        public IQueryable<z_PLC_Contador> Getz_PLC_Contador()
        {
            return db.z_PLC_Contador;
        }

        // GET: api/z_PLC_Contador/5
        [ResponseType(typeof(z_PLC_Contador))]
        public async Task<IHttpActionResult> Getz_PLC_Contador(int id)
        {
            z_PLC_Contador z_PLC_Contador = await db.z_PLC_Contador.FindAsync(id);
            if (z_PLC_Contador == null)
            {
                return NotFound();
            }

            return Ok(z_PLC_Contador);
        }

        // PUT: api/z_PLC_Contador/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putz_PLC_Contador(int id, z_PLC_Contador z_PLC_Contador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != z_PLC_Contador.Id)
            {
                return BadRequest();
            }

            db.Entry(z_PLC_Contador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!z_PLC_ContadorExists(id))
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

        // POST: api/z_PLC_Contador
        [ResponseType(typeof(z_PLC_Contador))]
        public async Task<IHttpActionResult> Postz_PLC_Contador(z_PLC_Contador z_PLC_Contador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.z_PLC_Contador.Add(z_PLC_Contador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = z_PLC_Contador.Id }, z_PLC_Contador);
        }

        // DELETE: api/z_PLC_Contador/5
        [ResponseType(typeof(z_PLC_Contador))]
        public async Task<IHttpActionResult> Deletez_PLC_Contador(int id)
        {
            z_PLC_Contador z_PLC_Contador = await db.z_PLC_Contador.FindAsync(id);
            if (z_PLC_Contador == null)
            {
                return NotFound();
            }

            db.z_PLC_Contador.Remove(z_PLC_Contador);
            await db.SaveChangesAsync();

            return Ok(z_PLC_Contador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool z_PLC_ContadorExists(int id)
        {
            return db.z_PLC_Contador.Count(e => e.Id == id) > 0;
        }
    }
}