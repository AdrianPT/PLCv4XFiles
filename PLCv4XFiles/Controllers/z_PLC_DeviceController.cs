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
{   // http://localhost:53725/api/z_PLC_Device/1
    public class z_PLC_DeviceController : ApiController
    {
        private PLCv4XFilesContext db = new PLCv4XFilesContext();

        // GET: api/z_PLC_Device
        public IQueryable<z_PLC_Device> Getz_PLC_Device()
        {
            return db.z_PLC_Device;
        }

        // GET: api/z_PLC_Device/5
        [ResponseType(typeof(z_PLC_Device))]
        public async Task<IHttpActionResult> Getz_PLC_Device(int id)
        {
            z_PLC_Device z_PLC_Device = await db.z_PLC_Device.FindAsync(id);
            if (z_PLC_Device == null)
            {
                return NotFound();
            }

            return Ok(z_PLC_Device);
        }

        // PUT: api/z_PLC_Device/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putz_PLC_Device(int id, z_PLC_Device z_PLC_Device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != z_PLC_Device.Id)
            {
                return BadRequest();
            }

            db.Entry(z_PLC_Device).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!z_PLC_DeviceExists(id))
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

        // POST: api/z_PLC_Device
        [ResponseType(typeof(z_PLC_Device))]
        public async Task<IHttpActionResult> Postz_PLC_Device(z_PLC_Device z_PLC_Device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.z_PLC_Device.Add(z_PLC_Device);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = z_PLC_Device.Id }, z_PLC_Device);
        }

        // DELETE: api/z_PLC_Device/5
        [ResponseType(typeof(z_PLC_Device))]
        public async Task<IHttpActionResult> Deletez_PLC_Device(int id)
        {
            z_PLC_Device z_PLC_Device = await db.z_PLC_Device.FindAsync(id);
            if (z_PLC_Device == null)
            {
                return NotFound();
            }

            db.z_PLC_Device.Remove(z_PLC_Device);
            await db.SaveChangesAsync();

            return Ok(z_PLC_Device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool z_PLC_DeviceExists(int id)
        {
            return db.z_PLC_Device.Count(e => e.Id == id) > 0;
        }
    }
}