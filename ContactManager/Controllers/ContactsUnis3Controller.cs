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
    public class ContactsUnis3Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactsUnis3
        public ActionResult Index()
        {
            return View(db.ContactsUnis.ToList());
        }

        // GET: ContactsUnis3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni contactsUni = db.ContactsUnis.Find(id);
            if (contactsUni == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni);
        }

        // GET: ContactsUnis3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsUnis3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Nome,Via,Citta,Stato,CodicePostale,Email,Zip,CompanyId,City,State")] ContactsUni contactsUni)
        {
            if (ModelState.IsValid)
            {
                db.ContactsUnis.Add(contactsUni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactsUni);
        }

        // GET: ContactsUnis3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni contactsUni = db.ContactsUnis.Find(id);
            if (contactsUni == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni);
        }

        // POST: ContactsUnis3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Nome,Via,Citta,Stato,CodicePostale,Email,Zip,CompanyId,City,State")] ContactsUni contactsUni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactsUni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactsUni);
        }

        // GET: ContactsUnis3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni contactsUni = db.ContactsUnis.Find(id);
            if (contactsUni == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni);
        }

        // POST: ContactsUnis3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactsUni contactsUni = db.ContactsUnis.Find(id);
            db.ContactsUnis.Remove(contactsUni);
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
