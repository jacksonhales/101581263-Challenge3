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
using Challenge3.API.Models;

namespace Challenge3.API.Controllers
{
    public class UserModulesAPIController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/UserModulesAPI
        public IQueryable<UserModule> GetUserModules()
        {
            return db.UserModules;
        }

        // GET: api/UserModulesAPI/5
        [ResponseType(typeof(UserModule))]
        public async Task<IHttpActionResult> GetUserModule(string id)
        {
            UserModule userModule = await db.UserModules.FindAsync(id);
            if (userModule == null)
            {
                return NotFound();
            }

            return Ok(userModule);
        }

        // PUT: api/UserModulesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserModule(string id, UserModule userModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModule.Id)
            {
                return BadRequest();
            }

            db.Entry(userModule).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModuleExists(id))
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

        // POST: api/UserModulesAPI
        [ResponseType(typeof(UserModule))]
        public async Task<IHttpActionResult> PostUserModule(UserModule userModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserModules.Add(userModule);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserModuleExists(userModule.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userModule.Id }, userModule);
        }

        // DELETE: api/UserModulesAPI/5
        [ResponseType(typeof(UserModule))]
        public async Task<IHttpActionResult> DeleteUserModule(string id)
        {
            UserModule userModule = await db.UserModules.FindAsync(id);
            if (userModule == null)
            {
                return NotFound();
            }

            db.UserModules.Remove(userModule);
            await db.SaveChangesAsync();

            return Ok(userModule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserModuleExists(string id)
        {
            return db.UserModules.Count(e => e.Id == id) > 0;
        }
    }
}