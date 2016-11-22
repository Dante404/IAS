using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Ajax.Utilities;
using ContactManager.Models;

namespace ContactManager.ViewModels
{
    public partial class ContattiDB2 : DbContext
    {
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactsUni>().ToTable("ContactsUni");
            throw new UnintentionalCodeFirstException();
        }*/

        public System.Data.Entity.DbSet<ContactManager.Models.Contatti> Contatti { get; set; }
        public System.Data.Entity.DbSet<ContactManager.Models.ContactsUni2> ContactsUni2 { get; set; }
    }

    public partial class ContactsUni3
    {
        private IQueryable<ContactsUni3> contacts;
        private IQueryable<ContactsUni3> contattis;
        private IQueryable<ContactsUni3> companies;
        private IQueryable<Contact> contacts1;
        private IQueryable<Contatti> contattis1;
        private IQueryable<Companies> companies1;


        public ContactsUni3()
        { }

        [Key, ForeignKey("Contatti")]
        public int ContattoID { get; set; }
        public IEnumerable<Contatti> Contattis { get; set; }
        public IEnumerable<Companies> Companies { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public virtual Contatti Contatti { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Companies Company { get; set; }
    }

}