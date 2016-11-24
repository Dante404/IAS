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
    public class ContactsUni21Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ContattiDB2 db2 = new ContattiDB2();

        // GET: ContactsUni21
        public ActionResult Index(String Page)
        {
         
            ContactsUni2 CU = new ContactsUni2();
            CU.Contattis = db2.Contatti.ToList();
            CU.Contacts = db.Contacts.ToList();
            CU.Companies = db.Companies.ToList();
            foreach (var contact in CU.Contacts)
            {
                contact.Companies = CU.Companies.Where(com => com.CompanyId == contact.CompanyId).ToList();
            }
            List<ContactsUni2> contactlist = new List<ContactsUni2>();
            contactlist.Add(CU);
            return View(contactlist);
        }

        // GET: ContactsUni21/Details/5
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

        // GET: ContactsUni21/Create
        public ActionResult Create()
        {
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome");
            return View();
        }

        // POST: ContactsUni21/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContattoID")] ContactsUni2 contactsUni2)
        {
            if (ModelState.IsValid)
            {
                db.ContactsUni2.Add(contactsUni2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni2.ContattoID);
            return View(contactsUni2);
        }

        // GET: ContactsUni21/Edit/5
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
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni2.ContattoID);
            return View(contactsUni2);
        }

        // POST: ContactsUni21/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContattoID")] ContactsUni2 contactsUni2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactsUni2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni2.ContattoID);
            return View(contactsUni2);
        }

        // GET: ContactsUni21/Delete/5
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

        // POST: ContactsUni21/Delete/5
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
