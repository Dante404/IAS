using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContattisController : Controller
    {
        private ContattiDB db = new ContattiDB();

        // GET: Contattis
        public ActionResult Index()
        {
            return View(db.Contatti.ToList());
        }

        // GET: Contattis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // GET: Contattis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contattis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContattoID,Nome,Via,Citta,Stato,CodicePostale,Email")] Contatti contatti)
        {
            if (ModelState.IsValid)
            {
                db.Contatti.Add(contatti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contatti);
        }

        // GET: Contattis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // POST: Contattis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContattoID,Nome,Via,Citta,Stato,CodicePostale,Email")] Contatti contatti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contatti);
        }

        // GET: Contattis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // POST: Contattis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contatti contatti = db.Contatti.Find(id);
            db.Contatti.Remove(contatti);
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
