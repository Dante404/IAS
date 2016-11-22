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
    public class ContactsUnis1Controller : Controller
    {
        private ContattiDB2 db2 = new ContattiDB2();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactsUnis1
        public ActionResult Index()
        {
            return View(db.ContactsUnis.ToList());
        }

        /*   public ActionResult ContactsUni()
        {
            var contacts = db.Contacts.ToList();
            var companies = db.Companies.ToList();
            var contatti = db2.Contatti2.ToList();
            var view = new ContactsUni()
            {
                Contacts = contacts,
                Companies = companies,
                Contattis = contatti
            };
            return View(view);
        }*/

        // GET: ContactsUnis1/Details/5
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

        // GET: ContactsUnis1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsUnis1/Create
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

        // GET: ContactsUnis1/Edit/5
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

        // POST: ContactsUnis1/Edit/5
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

        // GET: ContactsUnis1/Delete/5
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

        // POST: ContactsUnis1/Delete/5
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
