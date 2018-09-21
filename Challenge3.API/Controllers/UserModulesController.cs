using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge3.API.Models;

namespace Challenge3.API.Controllers
{
    public class UserModulesController : Controller
    {
        private Entities db = new Entities();

        // GET: UserModules
        public async Task<ActionResult> Index()
        {
            var userModules = db.UserModules.Include(u => u.AspNetUser).Include(u => u.Module);
            return View(await userModules.ToListAsync());
        }

        // GET: UserModules/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = await db.UserModules.FindAsync(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // GET: UserModules/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress");
            return View();
        }

        // POST: UserModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.UserModules.Add(userModule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // GET: UserModules/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = await db.UserModules.FindAsync(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // POST: UserModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // GET: UserModules/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = await db.UserModules.FindAsync(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // POST: UserModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserModule userModule = await db.UserModules.FindAsync(id);
            db.UserModules.Remove(userModule);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
