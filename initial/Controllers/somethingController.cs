using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using initial.Models;

namespace initial.Controllers
{
    public class somethingController : Controller
    {
        private initialContext db = new initialContext();

        // GET: something
        public ActionResult Index()
        {
            return View(db.something.ToList());
        }

        // GET: something/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            something something = db.something.Find(id);
            if (something == null)
            {
                return HttpNotFound();
            }
            return View(something);
        }

        // GET: something/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: something/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "somethingid,someName,someIDNumber")] something something)
        {
            if (ModelState.IsValid)
            {
                db.something.Add(something);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(something);
        }

        // GET: something/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            something something = db.something.Find(id);
            if (something == null)
            {
                return HttpNotFound();
            }
            return View(something);
        }

        // POST: something/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "somethingid,someName,someIDNumber")] something something)
        {
            if (ModelState.IsValid)
            {
                db.Entry(something).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(something);
        }

        // GET: something/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            something something = db.something.Find(id);
            if (something == null)
            {
                return HttpNotFound();
            }
            return View(something);
        }

        // POST: something/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            something something = db.something.Find(id);
            db.something.Remove(something);
            db.SaveChanges();
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
