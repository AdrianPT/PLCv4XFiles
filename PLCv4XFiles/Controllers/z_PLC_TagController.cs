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
    public class z_PLC_TagController : ApiController
    {
        private PLCv4XFilesContext db = new PLCv4XFilesContext();

        // GET: api/z_PLC_Tag
        public IQueryable<z_PLC_Tag> Getz_PLC_Tag()
        {
            return db.z_PLC_Tag;
        }

        // GET: api/z_PLC_Tag/5
        [ResponseType(typeof(z_PLC_Tag))]
        public async Task<IHttpActionResult> Getz_PLC_Tag(int id)
        {
            z_PLC_Tag z_PLC_Tag = await db.z_PLC_Tag.FindAsync(id);
            if (z_PLC_Tag == null)
            {
                return NotFound();
            }

            return Ok(z_PLC_Tag);
        }

        // PUT: api/z_PLC_Tag/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putz_PLC_Tag(int id, z_PLC_Tag z_PLC_Tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != z_PLC_Tag.Id)
            {
                return BadRequest();
            }

            db.Entry(z_PLC_Tag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!z_PLC_TagExists(id))
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

        // POST: api/z_PLC_Tag
        [ResponseType(typeof(z_PLC_Tag))]
        public async Task<IHttpActionResult> Postz_PLC_Tag(z_PLC_Tag z_PLC_Tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.z_PLC_Tag.Add(z_PLC_Tag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = z_PLC_Tag.Id }, z_PLC_Tag);
        }

        // DELETE: api/z_PLC_Tag/5
        [ResponseType(typeof(z_PLC_Tag))]
        public async Task<IHttpActionResult> Deletez_PLC_Tag(int id)
        {
            z_PLC_Tag z_PLC_Tag = await db.z_PLC_Tag.FindAsync(id);
            if (z_PLC_Tag == null)
            {
                return NotFound();
            }

            db.z_PLC_Tag.Remove(z_PLC_Tag);
            await db.SaveChangesAsync();

            return Ok(z_PLC_Tag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool z_PLC_TagExists(int id)
        {
            return db.z_PLC_Tag.Count(e => e.Id == id) > 0;
        }
    }
}