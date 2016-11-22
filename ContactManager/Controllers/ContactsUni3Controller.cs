using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;
using ContactManager.ViewModels;

namespace ContactManager.Controllers
{
    public class ContactsUni3Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactsUni3
        public ActionResult Index()
        {
            var viewModel = new ContactsUni3();
            viewModel.Contattis = db.Contattis
                .Include(i => i.ContattoID);
            viewModel.Contacts = db.Contacts;
            viewModel.Companies = db.Companies;
            return View(viewModel);
        }

        // GET: ContactsUni3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni3 contactsUni3 = db.ContactsUni3.Find(id);
            if (contactsUni3 == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni3);
        }

        // GET: ContactsUni3/Create
        public ActionResult Create()
        {
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome");
            return View();
        }

        // POST: ContactsUni3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContattoID")] ContactsUni3 contactsUni3)
        {
            if (ModelState.IsValid)
            {
                db.ContactsUni3.Add(contactsUni3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni3.ContattoID);
            return View(contactsUni3);
        }

        // GET: ContactsUni3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni3 contactsUni3 = db.ContactsUni3.Find(id);
            if (contactsUni3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni3.ContattoID);
            return View(contactsUni3);
        }

        // POST: ContactsUni3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContattoID")] ContactsUni3 contactsUni3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactsUni3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContattoID = new SelectList(db.Contattis, "ContattoID", "Nome", contactsUni3.ContattoID);
            return View(contactsUni3);
        }

        // GET: ContactsUni3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactsUni3 contactsUni3 = db.ContactsUni3.Find(id);
            if (contactsUni3 == null)
            {
                return HttpNotFound();
            }
            return View(contactsUni3);
        }

        // POST: ContactsUni3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactsUni3 contactsUni3 = db.ContactsUni3.Find(id);
            db.ContactsUni3.Remove(contactsUni3);
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
