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
    public class ContactsUni2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactsUni2
        public ActionResult Index()
        {
            return View(db.ContactsUni2.ToList());
        }

        // GET: ContactsUni2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni2 contactsUni2 = db.ContactsUni2.Find(id);
            if (contactsUni2 == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni2);
        }

        // GET: ContactsUni2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsUni2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uniID")] ContactsUni2 contactsUni2)
        {
            if (ModelState.IsValid)
            {
                db.ContactsUni2.Add(contactsUni2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactsUni2);
        }

        // GET: ContactsUni2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni2 contactsUni2 = db.ContactsUni2.Find(id);
            if (contactsUni2 == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni2);
        }

        // POST: ContactsUni2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uniID")] ContactsUni2 contactsUni2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactsUni2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactsUni2);
        }

        // GET: ContactsUni2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni2 contactsUni2 = db.ContactsUni2.Find(id);
            if (contactsUni2 == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni2);
        }

        // POST: ContactsUni2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactsUni2 contactsUni2 = db.ContactsUni2.Find(id);
            db.ContactsUni2.Remove(contactsUni2);
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
